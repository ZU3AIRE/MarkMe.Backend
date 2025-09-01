using MarkMe.Core.DTOs;

namespace MarkMe.Core.Services.Interface
{
    public interface ICRService
    {
        Task<CRDTO> AddAsync(AddUpdateCRDTO cr, string email);
        Task UpdateAsync(AddUpdateCRDTO cr, string email);
        Task<CRDTO?> GetAsync(int studentId);
        Task<IEnumerable<CRDTO>> GetAllAsync();
        Task<IEnumerable<CRDTO>> ToggleActive(int studentId, bool isDisabled);
        //Task<CourseDTO> UpdateAsync(CourseDTO course);
        Task<bool> DeleteAsync(int studentId);
    }
}
