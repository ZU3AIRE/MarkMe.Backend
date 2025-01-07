using MarkMe.Core.DTOs;

namespace MarkMe.Core.Services.Interface
{
    public interface ICRService
    {
        Task<CRDTO> AddAsync(CreateCRDTO cr);
        Task<CRDTO?> GetAsync(int studentId);
        Task<IEnumerable<CRDTO>> GetAllAsync();
        //Task<CourseDTO> UpdateAsync(CourseDTO course);
        //Task<bool> DeleteAsync(int courseId);
    }
}
