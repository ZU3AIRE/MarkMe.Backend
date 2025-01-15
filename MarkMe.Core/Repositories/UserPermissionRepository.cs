using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Entities;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class UserPermissionRepository(IDatabase _database) : IUserPermissionRepository
    {
        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            const string sql = """ 
					SELECT * 
					FROM Menus
					""";
            var res = await _database.QueryAsync<Menu>(sql);
            return res;
        }
    }
}
