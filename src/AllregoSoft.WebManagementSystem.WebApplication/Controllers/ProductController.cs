using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    [UserAuthorizationFilter]

    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            ViewBag.mall_Id = 369;
            return View();
        }
    }
}
