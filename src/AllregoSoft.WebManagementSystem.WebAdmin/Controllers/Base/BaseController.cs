using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public abstract partial class BaseController : Controller
    {
        public IConfiguration Configuration { get { return HttpContext.RequestServices?.GetService<IConfiguration>(); } }
        public IIdentityService IdentityService { get { return HttpContext.RequestServices?.GetService<IIdentityService>(); } }
        public string AppRoot { get { return HttpContext.RequestServices?.GetService<IHostEnvironment>().ContentRootPath; } }
        public string WebRoot { get { return HttpContext.RequestServices?.GetService<IWebHostEnvironment>().WebRootPath; } }

        private IMemberService _memberService { get { return HttpContext.RequestServices?.GetService<IMemberService>(); } }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Prepare();
            base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Prepare();
            return base.OnActionExecutionAsync(context, next);
        }

        public virtual void Prepare()
        {
            var identity = IdentityService.GetUserIdentity();
            var member = _memberService.GetMemberByIdentity(identity).GetAwaiter().GetResult();
        }
    }
}
