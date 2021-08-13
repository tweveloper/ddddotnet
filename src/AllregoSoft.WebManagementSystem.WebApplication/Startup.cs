using AllregoSoft.WebManagementSystem.WebApplication.Controllers;
using AllregoSoft.WebManagementSystem.WebApplication.Helper;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using AllregoSoft.WebManagementSystem.WebApplication.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllregoSoft.WebManagementSystem.WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static Dictionary<string, string> appSettings { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddScoped<webApiHelper>();
            services.AddScoped<Role_SiteMap>();
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter())
            )
            .AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            appSettings = Configuration.GetSection("AppSettings").GetChildren().ToDictionary(x => x.Key, x => x.Value);
#if DEBUG
            appSettings["ApiDomain"] = appSettings["ApiTestDomain"];
#endif
            services.AddControllersWithViews().AddSessionStateTempDataProvider();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddRazorPages().AddSessionStateTempDataProvider().AddRazorRuntimeCompilation();
            services.AddSingleton<TempDataSerializer, JsonTempDataSerializer>();
            //for cookies
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            //for session
            services.AddSingleton<ITempDataProvider, SessionStateTempDataProvider>();

            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AWMS.Session";
                // Set a short timeout for easy testing.
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SiteHelper.Services = app.ApplicationServices;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
