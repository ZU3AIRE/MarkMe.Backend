using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;
using Azure.AI.OpenAI;
using System.ClientModel;


namespace MarkMe.Core.Services
{
    public class AttendanceService(IAttendanceRepository _attendanceRepository, 
        ICourseRepository _courseRepository,
        IConfiguration _configuration) : IAttendanceService
    {
        public async Task<IEnumerable<AttendanceDataModel>> GetAllAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<IEnumerable<CoursesDTO?>> GetCRCoursesAsync()
        {
            return await _attendanceRepository.GetCoursesAsync();
        }

        public async Task<IEnumerable<CoursesDTO?>> GetTutorCourses(string email)
        {
            return await _attendanceRepository.GetTutorCoursesAsync(email);
        }

        public async Task<IEnumerable<AttendanceDataModel?>> GetByCourseId(int courseId)
        {
            return await _attendanceRepository.GetByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj, string userEmail)
        {
            var course = await _courseRepository.GetAsync(obj.CourseId);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            var attend = await _attendanceRepository.AddAsync(obj, course.Title, userEmail);
            return attend;
            

        }

        public async Task<AttendanceDataModel> UpdateAsync(int attendanceId, UpdateAttendanceDTO obj)
        {
            return await _attendanceRepository.UpdateAsync(obj.AttendanceId, obj);
        }
        public async Task<bool> DeleteAsync(int attendanceId)
        {
            return await _attendanceRepository.DeleteAsync(attendanceId);
        }

        public async Task<AttendanceDataModel?> GetByIdAsync(int attendanceId)
        {
            return await _attendanceRepository.GetByIdAsync(attendanceId);
        }

        public async Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds)
        {
            return await _attendanceRepository.BulkDeleteAsync(attendanceIds);
        }

        public async Task<IEnumerable<ValidStudents>> GetValidStudentsByRollNumbersAsync(List<string> rollNos)
        {
            return await _attendanceRepository.GetValidStudents(rollNos);
        }

        public async Task<IEnumerable<dynamic>> GetByPrompt(PromptAttendance userPrompt)
        {
            var endpoint = new Uri(_configuration["AzureOpenAI:Endpoint"]);
            var apiKey = new ApiKeyCredential(_configuration["AzureOpenAI:ApiKey"]);
            var deploymentName = _configuration["AzureOpenAI:Deployment"];

            AzureOpenAIClient _client = new AzureOpenAIClient(endpoint, apiKey);

            var systemChat = @"You are a highly knowledgeable and efficient assistant that converts natural language commands into syntactically correct and optimized SQL queries. 
                Your sole function is to return valid SQL statements that accurately reflect the user's intent.
                You must follow these rules: 
                Only return SQL — no explanations, summaries, or additional text. 
                Your SQL must strictly conform to the following schema:

                Tables and their columns:
                - Activities: ActivityId(INT PK), Description(NVARCHAR(MAX)), Date(DATETIME2), ClassRepresentativeStudentId(INT), ClassRepresentativeCourseId(INT)
                - Attendances: AttendanceId(INT PK), StudentId(INT), CourseId(INT), DateMarked(DATETIME2), MarkedBy(INT), Status(INT)
                - ClassRepresentatives: StudentId(INT PK), CourseId(INT PK), IsDeleted(INT), NominatedBy(INT), IsDisabled(BIT)
                - Courses: CourseId(INT PK), Code(NVARCHAR(12)), Title(NVARCHAR(100)), Type(INT), Semester(INT), CreditHours(INT), CreditHoursPerWeek(INT), IsArchived(BIT), AssignedTo(INT)
                - Departments: DepartmentId(INT PK), Name(NVARCHAR(100)), IsDeleted(BIT)
                - Enrolments: EnrolmentId(INT PK), StudentId(INT), CourseId(INT)
                - Menus: MenuId(INT PK), Label(NVARCHAR(MAX)), Url(NVARCHAR(MAX)), Role(INT)
                - Students: StudentId(INT PK), CollegeRollNo(NVARCHAR(8)), UniversityRollNo(NVARCHAR(12)), RegistrationNo(NVARCHAR(24)), FirstName(NVARCHAR(100)), LastName(NVARCHAR(100)), Session(NVARCHAR(18)), Section(NVARCHAR(18)), IsDeleted(BIT), Email(NVARCHAR(MAX))
                - Users: UserId(INT PK), FirstName(NVARCHAR(100)), LastName(NVARCHAR(100)), Email(NVARCHAR(200)), Password(NVARCHAR(200)), IsDeleted(BIT)";

           List<ChatMessage> messages = new List<ChatMessage>
          {
              new SystemChatMessage(systemChat),
              new UserChatMessage(userPrompt.Prompt)
          };

            ChatCompletionOptions chatCompletionsOptions = new ChatCompletionOptions()
            {
                Temperature = 0,
                MaxOutputTokenCount = 1000,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
                StopSequences =
                {
                    ";"
                }
            };

            var response = await _client.GetChatClient(deploymentName).CompleteChatAsync(
                      messages,
                      chatCompletionsOptions,
                      cancellationToken: default);

            var sql = response.Value.Content[0].Text;
            var data = await _attendanceRepository.GetAttendancebyPromt(sql);

            return data;
        }
    }
}
