using MarkMe.Core.DTOs;
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
            return Ok(await _studentService.UpdateAsync(student));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            return Ok(await _studentService.DeleteAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetCRNomineesAsync()
        {
            var students = await _studentService.GetCRNomineesAsync();
            return Ok(students);
        }
    }
}
