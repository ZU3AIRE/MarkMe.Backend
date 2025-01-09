using MarkMe.Core.DTOs;

namespace MarkMe.Core.Repositories.Interface
{
    public interface ICRRepository
    {
        Task<CRDTO?> GetAsync(int studentId);
        Task UpdateAsync(AddUpdateCRDTO obj);
        Task<IEnumerable<CRDTO>> GetAllAsync();
        Task<IEnumerable<CRDTO>> ToggleActive(int studentId, bool isActive);
        Task<CRDTO> AddAsync(AddUpdateCRDTO cr);
        //Task<CourseDTO> UpdateAsync(int id, CourseDTO updatedObj);
        //Task<bool> DeleteAsync(int id);
    }
}
