using MarkMe.Core.DTOs;
using MarkMe.Core.Services;
using MarkMe.Core.Services.Interface;
using MarkMe.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController(IStudentService _studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            var student = await _studentService.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] CreateStudentDTO student)
        {
            var createdStudent = await _studentService.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            var updated = await _studentService.UpdateAsync(student);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            return Ok(await _studentService.DeleteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> BulkDeleteStudents([FromBody] IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("No student IDs provided.");

            var result = await _studentService.BulkDeleteAsync(ids);
            if (result)
                return Ok(new { message = "Students deleted successfully." });
            return StatusCode(500, new { message = "Failed to delete students." });
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetCRNomineesAsync()
        {
            var students = await _studentService.GetCRNomineesAsync();
            return Ok(students);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDataModel>>> GetStudentsName()
        {
            var students = await _studentService.GetStudentsNameAsync();
            return Ok(students);
        }
    }
}
