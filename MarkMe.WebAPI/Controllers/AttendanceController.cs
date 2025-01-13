using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceController(IAttendanceService _attendanceService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDataModel>>> GetAllAttendance()
        {
            var attend = await _attendanceService.GetAllAsync();
            return (attend != null) ? Ok(attend) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDataModel>> AddAttendance(AddAttendanceDTO obj)
        {
            var attend = await _attendanceService.AddAsync(obj);
            return (attend != null) ? Ok(attend) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AttendanceDataModel>> UpdateAttendance(int id, UpdateAttendanceDTO obj)
        {
            if (id != obj.AttendanceId)
            {
                return BadRequest();
            }

            var atttend = await _attendanceService.UpdateAsync(id, obj);
            return Ok(atttend);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttendance(int id)
        {
            var deleted = await _attendanceService.DeleteAsync(id);
            return (deleted) ? Ok(deleted) : NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> BulkDeleteAttendance(BulkDeleteAttendanceDTO attendanceIds)
        {
            var deleted = await _attendanceService.BulkDeleteAsync(attendanceIds);
            return (deleted) ? Ok(deleted) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDataModel>> GetAttendanceById(int id)
        {
            var attend = await _attendanceService.GetByIdAsync(id);
            return (attend != null) ? Ok(attend) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDataModel?>> GetAttendanceByCourseId(int id)
        {
            var attend = await _attendanceService.GetByCourseId(id);
            return (attend != null) ? Ok(attend) : NotFound();
        }
    }
}
