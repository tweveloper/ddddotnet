using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityParser<ApplicationUser> _appUserParser;

        public HomeController(ILogger<HomeController> logger, IMemberService memberService, IIdentityParser<ApplicationUser> appUserParser)
        {
            _logger = logger;
            _memberService = memberService;
            _appUserParser = appUserParser;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var user = _appUserParser.Parse(HttpContext.User);
                var vm = await _memberService.GetMember(user.Id);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Test()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return View(token);
        }
    }
}
