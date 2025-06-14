using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;
using Azure.AI.OpenAI;
using System.ClientModel;
using Newtonsoft.Json;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;


namespace MarkMe.Core.Services
{
    public class AttendanceService(IAttendanceRepository _attendanceRepository,
        ICourseRepository _courseRepository,
        IConfiguration _configuration,
        IStudentRepository _studentRepo) : IAttendanceService
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

            var systemChat = @"You're a smart SQL assistant. You only reply with valid unformatted SQL Server (T-SQL) queries based on user commands. No chitchat, no explaining, no extra info.

                            Rules:

                            Always respond in a structured JSON format with two keys: ""sql"" and ""status"".

                            ""sql"" must contain the raw SQL Server-compatible query in one line if possible.

                            ""status"" must be ""success"" if query is returned, otherwise ""failed"".

                            If the query can’t be answered with the given tables/columns, respond like this:
                            { ""sql"": """", ""status"": ""failed"", ""message"": ""Query out of scope, 😐"" }

                            When filtering by today's date or comparing dates, use the following correct SQL Server format to ignore time:
                            CAST(DateColumn AS date) = CAST(GETDATE() AS date)

                            When user requests complete attendance information for students, return meaningful details by joining tables:

                            - Student Name (FirstName + LastName as StudentName)
                            - Roll No (CollegeRollNo as RollNo)
                            - Course Title (Courses.Title as Course)
                            - Attendance Status (use CASE to convert status ID to text like Present, Absent, etc. as AttendanceStatus)
                            - Date of Attendance (DateMarked)

                            Always use aliases when returning any column.

                            Use only the following schema and column mappings:

                            Table: Students  
                            CollegeRollNo (Roll No)  
                            FirstName, LastName (Name)  
                            Other: StudentId, UniversityRollNo, RegistrationNo, Session, Section, IsDeleted, Email

                            Table: Courses  
                            Title (Course)  
                            Other: CourseId, Code, Type, Semester, CreditHours, CreditHoursPerWeek, IsArchived, AssignedTo

                            Table: Attendances  
                            Status (1 = Absent, 2 = Present, 3 = Leave, 4 = Late)  
                            DateMarked (Date)  
                            Other: AttendanceId, StudentId, CourseId, MarkedBy

                            Table: Activities  
                            Description  
                            Date (Date)  
                            Other: ActivityId, ClassRepresentativeStudentId, ClassRepresentativeCourseId

                            Table: ClassRepresentatives  
                            StudentId, CourseId, IsDeleted, NominatedBy, IsDisabled

                            Table: Users  
                            UserId, FirstName, LastName, Email, Password, IsDeleted";

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

            var chat = response.Value.Content[0].Text;
            var chatResponse = JsonConvert.DeserializeObject<ChatResponseDTO>(chat);
            IEnumerable<dynamic> data = new List<dynamic>();
            if (chatResponse.status == "success")
            {
                data = await _attendanceRepository.GetAttendancebyPromt(chatResponse.sql);
            }

            return data;
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateAsync(DateTime date)
        {
            return await _attendanceRepository.GetAttendanceByDateAsync(date);
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _attendanceRepository.GetAttendanceByDateRangeAsync(startDate, endDate);
        }

        public async Task<bool> RegisterFace(StudentImages std)
        {
            string personGroupId = _configuration["AzureFace:PersonGroupId"];
            FaceClient _faceClient = new FaceClient(new ApiKeyServiceClientCredentials(_configuration["AzureFace:ApiKey"]))
            {
                Endpoint = _configuration["AzureFace:Endpoint"]
            };

            var student = await _studentRepo.GetStudentAsync(Convert.ToInt32(std.StudentId));


            if (std.Images == null || std.Images.Count() < 2 || std.Images.Count() > 4)
                throw new Exception("Provide 2 to 4 clear images of the student.");

            var faceIds = new List<Guid>();

            //foreach (var img in std.Images)
            //{
            //    var stream = img.OpenReadStream(); // Don't use 'using' here

            //    try
            //    {
            //        var detectedFaces = await _faceClient.Face.DetectWithStreamAsync(
            //            stream,
            //            returnFaceId: true,
            //            detectionModel: DetectionModel.Detection03
            //        );

            //        if (detectedFaces == null || detectedFaces.Count != 1)
            //            throw new Exception("Each image must contain exactly one face.");

            //        faceIds.Add(detectedFaces[0].FaceId.Value);
            //    }
            //    catch(Exception ex)
            //    {

            //    }
            //    finally
            //    {
            //        stream.Dispose(); // Dispose manually AFTER usage
            //    }
            //}

            foreach (var img in std.Images)
            {
                using var memoryStream = new MemoryStream();
                await img.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                try
                {
                    var detectedFaces = await _faceClient.Face.DetectWithStreamAsync(
                        memoryStream,
                        returnFaceId: true,
                        detectionModel: DetectionModel.Detection03
                    );

                    if (detectedFaces == null || detectedFaces.Count != 1)
                        throw new Exception("Each image must contain exactly one face.");

                    faceIds.Add(detectedFaces[0].FaceId.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Detection failed for one image: {ex.Message}");
                }
            }


            // Now verify that all face IDs are from the same person
            for (int i = 1; i < faceIds.Count; i++)
            {
                var verifyResult = await _faceClient.Face.VerifyFaceToFaceAsync(faceIds[0], faceIds[i]);
                if (!verifyResult.IsIdentical || verifyResult.Confidence < 0.6)
                {
                    throw new Exception("Uploaded images do not appear to be of the same person.");
                }
            }

            try
            {
                var personGroup = await _faceClient.PersonGroup.GetAsync(personGroupId);
                Console.WriteLine("✅ PersonGroup exists: " + personGroup.Name);
            }
            catch (APIErrorException ex) when (ex.Response.StatusCode == HttpStatusCode.NotFound)
            {
                // PersonGroup does not exist, so create it
                await _faceClient.PersonGroup.CreateAsync(personGroupId, "Students Group");
                Console.WriteLine("✅ PersonGroup created.");
            }


            Person person = await _faceClient.PersonGroupPerson.CreateAsync(
                personGroupId,
                student.FirstName + " " + student.LastName,
                userData: $"StudentId:{std.StudentId}"
            );

            foreach (var image in std.Images)
            {
                using var stream = image.OpenReadStream();
                await _faceClient.PersonGroupPerson.AddFaceFromStreamAsync(
                    personGroupId,
                    person.PersonId,
                    stream
                );
            }

            await _faceClient.PersonGroup.TrainAsync(personGroupId);

            TrainingStatus status;
            do
            {
                await Task.Delay(1000);
                status = await _faceClient.PersonGroup.GetTrainingStatusAsync(personGroupId);
            } while (status.Status == TrainingStatusType.Running);

            if (status.Status != TrainingStatusType.Succeeded)
                throw new Exception("Face training failed.");

            return true;

            //await studentService.UpdatePersonIdAsync(std.StudentId, person.PersonId.ToString());
        }
    }
}
