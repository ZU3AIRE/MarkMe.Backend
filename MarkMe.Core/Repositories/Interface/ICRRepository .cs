using MarkMe.Core.DTOs;

namespace MarkMe.Core.Repositories.Interface
{
    public interface ICRRepository
    {
        Task<CRDTO?> GetAsync(int studentId);
        Task<IEnumerable<CRDTO>> GetAllAsync();
        Task<CRDTO> AddAsync(CreateCRDTO cr);
        //Task<CourseDTO> UpdateAsync(int id, CourseDTO updatedObj);
        //Task<bool> DeleteAsync(int id);
    }
}
