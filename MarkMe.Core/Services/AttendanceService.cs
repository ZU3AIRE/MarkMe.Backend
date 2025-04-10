using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;

namespace MarkMe.Core.Services
{
    public class AttendanceService(IAttendanceRepository _attendanceRepository, ICourseRepository _courseRepository) : IAttendanceService
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
        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateAsync(DateTime date)
        {
            return await _attendanceRepository.GetAttendanceByDateAsync(date);
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _attendanceRepository.GetAttendanceByDateRangeAsync(startDate, endDate);
        }
    }
}
