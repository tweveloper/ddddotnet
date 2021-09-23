using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Controllers
{
    public class SignOutController : Controller
    {
        private readonly ILogger<SignOutController> _logger;

        public SignOutController(ILogger<SignOutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
