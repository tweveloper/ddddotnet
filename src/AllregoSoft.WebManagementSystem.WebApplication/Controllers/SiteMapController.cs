using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    [UserAuthorizationFilter]

    public class SiteMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}