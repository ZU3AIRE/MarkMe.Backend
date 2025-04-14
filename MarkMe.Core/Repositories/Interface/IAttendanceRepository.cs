using MarkMe.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.Repositories.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AttendanceDataModel>> GetAllAsync();
        Task<IEnumerable<CoursesDTO>> GetCoursesAsync();
        Task<IEnumerable<CoursesDTO>> GetTutorCoursesAsync(string email);
        Task<IEnumerable<AttendanceDataModel?>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<ValidStudents>> GetValidStudents(List<string> rollNos);
        Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj, string courseTitle, string userEmail);
        Task<AttendanceDataModel> UpdateAsync(int id, UpdateAttendanceDTO obj);
        Task<bool> DeleteAsync(int id);
        Task<AttendanceDataModel?> GetByIdAsync(int id);
        Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds);
        Task<AttendanceDataModel> GetAttendancebyPromt(PromptAttendance prompt);
    }
}
