using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "admin,tutor,cr")]
    public class AttendanceController(IAttendanceService _attendanceService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDataModel>>> GetAllAttendance()
        {
            var attend = await _attendanceService.GetAllAsync();
            return (attend != null) ? Ok(attend) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoursesDTO>>> GetCourses()
        {
            if (User.IsInRole("cr"))
            {
                var attend = await _attendanceService.GetCRCoursesAsync();
                return (attend != null) ? Ok(attend) : NotFound();
            }
            else if (User.IsInRole("tutor"))
            {
                var userEmail = User.Claims
                    .Select(claim => claim.Value).FirstOrDefault();
                var attend = await _attendanceService.GetTutorCourses(userEmail);
                return (attend != null) ? Ok(attend) : NotFound();
            }
            return Forbid("Unable to Authenticate.");
        }

        [HttpPost]
        public async Task<ActionResult> AddAttendance(AddAttendanceDTO obj)
        {
            if (obj == null || obj.CourseId <= 0 || obj.StudentsRollNos is " ")
            {
                return BadRequest(new { message = "Invalid input data." });
            }

            try
            {
                var email = User.Claims.Select(claim => claim.Value).FirstOrDefault();
                var rollNumbers = obj.StudentsRollNos.Trim().Split(",").ToList();
                var validStudents = await _attendanceService.GetValidStudentsByRollNumbersAsync(rollNumbers);
                var validRollNumbers = validStudents.Select(s => s.RollNo).ToList();
                var invalidRollNumbers = rollNumbers.Except(validRollNumbers).ToList();

                var attend = new AttendanceDTO
                {
                    CourseId = obj.CourseId,
                    StudentIds = validStudents.Select(s => s.StudentId).ToList(),
                };

                if (validStudents.Any())
                {
                    await _attendanceService.AddAsync(attend, email);
                }

                return Ok(new
                {
                    message = "Attendance marked successfully.",
                    invalidRollNumbers
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message});
            }
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
