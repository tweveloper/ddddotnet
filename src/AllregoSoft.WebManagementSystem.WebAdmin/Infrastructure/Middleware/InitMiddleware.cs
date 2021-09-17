using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Helper;
using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Middleware
{
    public class InitMiddleware
    {
        private readonly RequestDelegate _next;
        public InitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IIdentityParser<ApplicationUser> appUserParser)
        {
            var user = appUserParser.Parse(httpContext.User);
            //var option = httpContext.Request.Query["option"];

            //if (!string.IsNullOrWhiteSpace(option))
            //{
            //    httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            //}

            await _next(httpContext);
        }
    }
}
