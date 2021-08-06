using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            TempData.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
