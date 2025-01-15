using MarkMe.Database.Entities;

namespace MarkMe.Core.Repositories.Interface
{
    public interface IUserPermissionRepository
    {
        Task<IEnumerable<Menu>> GetAllAsync();
    }
}
