using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.CreateMember;
using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;
        private readonly IIdentityParser<ApplicationUser> _appUserParser;
        //private readonly UserManager<ApplicationUser> _userManager;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService, IIdentityParser<ApplicationUser> appUserParser)
        {
            _logger = logger;
            _memberService = memberService;
            _appUserParser = appUserParser;
            //_userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command)
        {
            var registerViewModel = new RegisterViewModel
            {
                Email = command.Email,
                Password = command.Password,
                ConfirmPassword = command.Password
            };

            var userIdentityId = await _memberService.CreateAuthentication(registerViewModel);

            command.IdentityId = userIdentityId;

            await _memberService.CreateMember(command);

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            //var user = new ApplicationUser
            //{
            //    Account = form["eamil"],
            //    UserName = form["eamil"],
            //    Email = form["eamil"],
            //};
            //var result = await _userManager.CreateAsync(user, form["password"]);
            //if (result.Errors.Count() > 0)
            //{
            //    // If we got this far, something failed, redisplay form
            //    return View();
            //}


            var registerViewModel = new RegisterViewModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };

            var userIdentityId = await _memberService.CreateAuthentication(registerViewModel);

            return View();
        }
    }
}
