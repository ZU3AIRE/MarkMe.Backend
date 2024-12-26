using MarkMe.Database.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMe.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDatabase, DapperDatabase>(provider => new DapperDatabase(connectionString));
            return services;
        }
    }
}
