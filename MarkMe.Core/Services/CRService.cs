using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;

namespace MarkMe.Core.Services
{
    public class CRService(ICRRepository _repo) : ICRService
    {
        public async Task<IEnumerable<CRDTO>> GetAllAsync()
        {
            var crs = await _repo.GetAllAsync();
            return crs;
        }

        public async Task<CRDTO> AddAsync(AddUpdateCRDTO obj)
        {
            var cr = await _repo.AddAsync(obj);
            return cr;

        }

        public async Task UpdateAsync(AddUpdateCRDTO obj)
        {
            await _repo.UpdateAsync(obj);
        }

        public async Task<CRDTO?> GetAsync(int studentId)
        {
            var cr = await _repo.GetAsync(studentId);
            return cr;
        }

        public async Task<IEnumerable<CRDTO>> ToggleActive(int studentId, bool isDisabled)
        {
            return await _repo.ToggleActive(studentId, isDisabled);
        }
    }
}
