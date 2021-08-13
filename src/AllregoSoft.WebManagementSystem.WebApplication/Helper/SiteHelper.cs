using AllregoSoft.WebManagementSystem.WebApplication.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApplication.Helper
{
    public static class SiteHelper
    {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static HttpContext HttpContextCurrent
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        /// <summary>
        /// Configuration settings from appsetting.json.
        /// </summary>
        public static AppSettings Config
        {
            get
            {
                //This works to get file changes.
                var s = services.GetService(typeof(IOptionsMonitor<AppSettings>)) as IOptionsMonitor<AppSettings>;
                AppSettings config = s.CurrentValue;

                return config;
            }
        }

        public static ISession CurrentSession
        {
            get
            {
                return HttpContextCurrent.Session;
            }
        }
    }
}
