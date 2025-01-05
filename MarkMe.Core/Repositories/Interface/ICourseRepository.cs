using MarkMe.Core.DTOs;

namespace MarkMe.Core.Repositories.Interface
{
    public interface ICourseRepository
    {
        Task<CourseDTO?> GetAsync(int id);
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> AddAsync(CourseDTO obj);
        Task<CourseDTO> UpdateAsync(int id, CourseDTO updatedObj);
        Task<bool> DeleteAsync(int id);
    }
}
