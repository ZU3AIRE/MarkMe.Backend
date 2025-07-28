using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using MarkMe.Database.Enums;
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
                var email = User.Claims.Select(claim => claim.Value).FirstOrDefault();
                var attend = await _attendanceService.GetCRCoursesAsync(email);
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
            if (obj == null || obj.CourseId <= 0 || !obj.StudentsRollNos.Any())
            {
                return BadRequest(new { message = "Invalid input data." });
            }

            try
            {
                var email = User.Claims.Select(claim => claim.Value).FirstOrDefault();
                var rollNumbers = obj.StudentsRollNos.Split(",").Select(r => r.Trim()).ToList();
                var validStudents = await _attendanceService.GetValidStudentsByRollNumbersAsync(rollNumbers);
                var validRollNumbers = validStudents.Select(s => s.RollNo).ToList();
                var invalidRollNumbers = rollNumbers.Except(validRollNumbers).ToList();

                var attend = new AttendanceDTO
                {
                    CourseId = obj.CourseId,
                    StudentIds = validStudents.Select(s => s.StudentId).ToList(),
                    DateMarked = obj.DateMarked,
                    AttendanceStatus = (AttendanceStatus)obj.Status
                };

                if (validStudents.Any())
                {
                    await _attendanceService.AddAsync(attend, email);
                }
                if (validRollNumbers.Any() && invalidRollNumbers.Any())
                {
                    return Ok(new
                    {
                        message = "Attendance marked successfully.",
                        invalidRollNumbers
                    });
                }
                else if (invalidRollNumbers.Any() && !validRollNumbers.Any())
                {
                    return Ok(new
                    {
                        invalidRollNumbers
                    });
                }

                return Ok(new
                {
                    message = "Attendance marked successfully.",
                    invalidRollNumbers
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
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

        [HttpPost]
        public async Task<IActionResult?> GetAttendanceByPrompt(PromptAttendance prompt)
        {
            var attend = await _attendanceService.GetByPrompt(prompt);
            return (attend != null) ? Ok(attend) : NotFound();
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<AttendanceDataModel>>> GetAttendanceByDate(DateTime date)
        {
            var attendances = await _attendanceService.GetAttendanceByDateAsync(date);
            return (attendances != null) ? Ok(attendances) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDataModel>>> GetAttendanceByDateRange(DateTime startDate, DateTime endDate)
        {
            var attendances = await _attendanceService.GetAttendanceByDateRangeAsync(startDate, endDate);
            return (attendances != null) ? Ok(attendances) : NotFound();
        }
    }
}
