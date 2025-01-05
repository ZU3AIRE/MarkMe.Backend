using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;

namespace MarkMe.Core.Services
{
    public class CourseService(ICourseRepository _repo) : ICourseService
    {
        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _repo.GetAllAsync();
            return courses;
        }

        public async Task<CourseDTO> GetAsync(int id)
        {
            var course = await _repo.GetAsync(id);
            return course;
        }

        public async Task<CourseDTO> AddAsync(CreateCourseDTO course)
        {
            var newCourse = new CourseDTO
            {
                Code = course.Code,
                Title = course.Title,
                Type = course.Type,
                Semester = course.Semester,
                CreditHours = course.CreditHours,
                CreditHoursPerWeek = course.CreditHoursPerWeek
            };

            var addedCourse = await _repo.AddAsync(newCourse);
            return addedCourse;
        }

        public async Task<CourseDTO> UpdateAsync(CourseDTO course)
        {
            var updatedCourse = await _repo.UpdateAsync(course.CourseId, course);
            return updatedCourse;
        }

        public async Task<bool> DeleteAsync(int courseId)
        {
            return await _repo.DeleteAsync(courseId);
        }
    }
}
