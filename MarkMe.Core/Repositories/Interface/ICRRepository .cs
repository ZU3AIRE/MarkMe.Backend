using MarkMe.Core.DTOs;

namespace MarkMe.Core.Repositories.Interface
{
    public interface ICRRepository
    {
        //Task<CourseDTO?> GetAsync(int id);
        Task<IEnumerable<CRDTO>> GetAllAsync();
        //Task<CourseDTO> AddAsync(CourseDTO obj);
        //Task<CourseDTO> UpdateAsync(int id, CourseDTO updatedObj);
        //Task<bool> DeleteAsync(int id);
    }
}
