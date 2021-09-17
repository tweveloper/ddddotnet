using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Filters
{
    public class InitFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<InitMiddleware>();
                next(builder);
            };
        }
    }
}
