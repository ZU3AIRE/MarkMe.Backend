using MarkMe.Core.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMe.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourse, CourseService>();
            return services;
        }
    }
}
