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
        Task<IEnumerable<AttendanceDataModel?>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj);
        Task<AttendanceDataModel> UpdateAsync(int id, UpdateAttendanceDTO obj);
        Task<bool> DeleteAsync(int id);
        Task<AttendanceDataModel?> GetByIdAsync(int id);
        Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds);
    }
}
