using Employee_Management.Data.Empolyees;
using Employee_Management.Data.Permissions;
using Employee_Management.Data.Users;

namespace Employee_Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Employee management services
            services.AddScoped<IEmpUnitOfWork, EmpUnitOfWork>();

            // User & Role management services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

            // Permission management services
            services.AddScoped<IPermissionsUnitOfWork, PermissionsUnitOfWork>();

            // Audit service
            services.AddScoped<IAuditService, AuditService>();

            return services;
        }
    }
}
