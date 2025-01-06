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
    }
}
