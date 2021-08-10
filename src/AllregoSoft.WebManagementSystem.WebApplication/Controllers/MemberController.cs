using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    [UserAuthorizationFilter]

    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MemberInfo(int? Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}