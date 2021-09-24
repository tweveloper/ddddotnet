using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Commands;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.WebAdmin.Infrastructure.Helper;
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
        private IScmMemberService _scmMemberService { get { return HttpContext.RequestServices?.GetService<IScmMemberService>(); } }

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
            var identity = IdentityService.GetIdentityId();

#if DEBUG

            if(IdentityService.GetClaimsPrincipal().HasClaim(c => c.Type == "account"))
            {
                var identityAccount = IdentityService.GetClaimsPrincipal().FindFirst("account").Value;
                if (identityAccount != null && identityAccount.Equals("admin"))
                {
                    var result = _scmMemberService.GetScmMemberByIdentity(identity).GetAwaiter().GetResult();
                    if (result.Id == 0)
                    {
                        _scmMemberService.CreateScmMember(new CreateScmMemberCommand
                        {
                            IdentityId = identity,
                            KeyId = 0,
                        }).GetAwaiter().GetResult();
                    }
                }
            }

#endif

            var member = _scmMemberService.GetScmMemberByIdentity(identity).GetAwaiter().GetResult();

            if(SessionHelper.ScmMember == null)
            {
                SessionHelper.ScmMember = member;
            }
        }
    }
}
