using MarkMe.Core.Interface;
using MarkMe.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMe.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourse, CourseService>();
            services.AddScoped<IStudent, StudentService>();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
