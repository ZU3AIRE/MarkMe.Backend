using MarkMe.Core.DTOs;

namespace MarkMe.Core.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDataModel>> GetAllAsync();
        Task<IEnumerable<AttendanceDataModel?>> GetByCourseId(int courseId);
        Task<IEnumerable<AttendanceDataModel>> AddAsync(AddAttendanceDTO obj);
        Task<AttendanceDataModel> UpdateAsync(int attendanceId, UpdateAttendanceDTO obj);
        Task<bool> DeleteAsync(int attendanceId);
        Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds);
        Task<AttendanceDataModel?> GetByIdAsync(int attendanceId);
    }
}
