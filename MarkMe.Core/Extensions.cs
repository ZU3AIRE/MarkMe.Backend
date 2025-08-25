﻿using MarkMe.Core.Repositories;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services;
using MarkMe.Core.Services.Interface;
using MarkMe.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarkMe.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICRRepository, CRRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<HttpClient>();

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICRService, CRService>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
