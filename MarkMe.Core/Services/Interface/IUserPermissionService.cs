using MarkMe.Database.Entities;

namespace MarkMe.Core.Services.Interface
{
    public interface IUserPermissionService
    {
        Task<IEnumerable<Menu>> GetAllAsync();
    }
}
