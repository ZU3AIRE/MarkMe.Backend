using MarkMe.Core.DTOs;
using MarkMe.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MarkMe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController(ICourseService _courseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
        {
            var course = await _courseService.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> CreateCourse(CreateCourseDTO course)
        {
            var createdCourse = await _courseService.AddAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseId }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseDTO course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            return Ok(await _courseService.UpdateAsync(course));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return Ok(await _courseService.DeleteAsync(id));
        }
    }
}
