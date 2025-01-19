using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;
using MarkMe.Database.Entities;

namespace MarkMe.Core.Services
{
    public class UserPermissionService(IUserPermissionRepository _userPermissionRepository) : IUserPermissionService
    {
        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _userPermissionRepository.GetAllAsync();
        }
    }
}
