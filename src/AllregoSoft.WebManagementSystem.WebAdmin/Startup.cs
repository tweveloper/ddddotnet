using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure;
using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Serialization;

namespace AllregoSoft.WebManagementSystem.WebAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .Services
                .AddCustomMvc(Configuration)
                .AddHttpClientServices(Configuration);

                   // PII(Personally Identifiable Information :  개인정보)가 로그에 표시되는지 여부를 나타내는 플래그입니다. 기본적으로 거짓입니다.
            IdentityModelEventSource.ShowPII = true;       // Caution! Do NOT use in production: https://aka.ms/IdentityModel/PII

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddCustomAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
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
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSession();

            // Fix samesite issue when running eShop from docker-compose locally as by default http protocol is being used
            // Refer to https://github.com/dotnet-architecture/eShopOnContainers/issues/1391
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultError", "{controller=Error}/{action=Error}");
                endpoints.MapControllers();
            });
        }
    }

    static class ServiceCollectionExtensions
    {

        //public static IServiceCollection AddAppInsight(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddApplicationInsightsTelemetry(configuration);
        //    services.AddApplicationInsightsKubernetesEnricher();

        //    return services;
        //}

        //public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddHealthChecks()
        //        .AddCheck("self", () => HealthCheckResult.Healthy())
        //        .AddUrlGroup(new Uri(configuration["IdentityUrlHC"]), name: "identityapi-check", tags: new string[] { "identityapi" });

        //    return services;
        //}

        public static IServiceCollection AddCustomMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages().AddSessionStateTempDataProvider().AddRazorRuntimeCompilation();
            services.AddOptions();
            services.Configure<AppSettings>(configuration);
            services.AddSession();
            services.AddDistributedMemoryCache();

            return services;
        }

        // Adds all Http client services
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register delegating handlers
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddTransient<HttpClientRequestIdDelegatingHandler>();

            //set 5 min as the lifetime for each HttpMessageHandler int the pool
            services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));//.AddDevspacesSupport();

            //add http client services
            services.AddHttpClient<IMemberService, MemberService>()
                   //.SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Sample. Default lifetime is 2 minutes
                   .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                   .AddHttpMessageHandler<HttpClientRequestIdDelegatingHandler>();

            //services.AddHttpClient<ICatalogService, CatalogService>()
            //       .AddDevspacesSupport();

            //services.AddHttpClient<IOrderingService, OrderingService>()
            //     .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //     .AddHttpMessageHandler<HttpClientRequestIdDelegatingHandler>()
            //     .AddDevspacesSupport();


            //add custom application services
            services.AddTransient<IIdentityParser<ApplicationUser>, IdentityParser>();

            return services;
        }


        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var identityUrl = configuration.GetValue<string>("IdentityUrl");
            var callBackUrl = configuration.GetValue<string>("CallBackUrl");
            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            // Add Authentication services          

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = identityUrl.ToString();
                options.SignedOutRedirectUri = callBackUrl.ToString();
                options.ClientId = "mvc";
                options.ClientSecret = "Allr2goS@ftSecretKey";
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = false;
                options.Scope.Add("awms.api.full");
            });

            return services;
        }
    }
}
