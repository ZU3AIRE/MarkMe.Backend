using MarkMe.Core.DTOs;

namespace MarkMe.Core.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDataModel>> GetAllAsync();
        Task<IEnumerable<CoursesDTO>> GetCRCoursesAsync(string email);
        Task<IEnumerable<CoursesDTO>> GetTutorCourses(string email);
        Task<IEnumerable<AttendanceDataModel?>> GetByCourseId(int courseId);
        Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj, string userEmail);
        Task<IEnumerable<ValidStudents>> GetValidStudentsByRollNumbersAsync(List<string> rollNos);
        Task<AttendanceDataModel> UpdateAsync(int attendanceId, UpdateAttendanceDTO obj);
        Task<bool> DeleteAsync(int attendanceId);
        Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds);
        Task<AttendanceDataModel?> GetByIdAsync(int attendanceId);
        Task<IEnumerable<dynamic>> GetByPrompt(PromptAttendance prompt);
        Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateAsync(DateTime date);
        Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<FaceRegistrationResult> RegisterFace(StudentImages stdImg);
        Task<FaceRegistrationResult> UpdateFace(StudentImages stdImg);
        Task<List<StudentFaceGallery>> GetStudentFaceGallery();
        Task<bool> DeleteStudentFacesAsync(int studentId);
    }
}
