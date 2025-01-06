using MarkMe.Core.DTOs;

namespace MarkMe.Core.Services.Interface
{
    public interface ICourseService
    {
        Task<CourseDTO> AddAsync(CreateCourseDTO course);
        Task<CourseDTO> GetAsync(int id);
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> UpdateAsync(CourseDTO course);
        Task<bool> DeleteAsync(int courseId);
    }
}
