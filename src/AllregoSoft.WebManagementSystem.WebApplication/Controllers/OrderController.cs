using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    [UserAuthorizationFilter]

    public class OrderController : Controller
    {
        public IActionResult OrderList()
        {
            ViewBag.mall_Id = 369;
            return View();
        }
    }
}
