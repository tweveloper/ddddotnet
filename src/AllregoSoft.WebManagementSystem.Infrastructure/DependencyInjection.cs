using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Data;
using AllregoSoft.WebManagementSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace AllregoSoft.WebManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AwmsDbContext>(options =>
            {
                options.UseSqlServer(configuration["AWMS.Application.ConnectionString"],
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.MigrationsAssembly(typeof(AwmsDbContext).GetTypeInfo().Assembly.FullName);
                              sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                          });
            }, ServiceLifetime.Scoped);
                    
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AwmsDbContext>());
            services.AddScoped<IDomainEventService, DomainEventService>();

            return services;
        }

        public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AwmsIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration["AWMS.Application.ConnectionString"],
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.MigrationsAssembly(typeof(AwmsIdentityDbContext).GetTypeInfo().Assembly.FullName);
                              sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                          });
            }, ServiceLifetime.Scoped);

            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<AwmsIdentityDbContext>());

            return services;
        }
    }
}
