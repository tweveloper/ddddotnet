using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly Role_SiteMap _roleSite;

        public ProductController(Role_SiteMap RoleSite)
        {
            _roleSite = RoleSite;
        }

        public IActionResult ProductList()
        {
            ViewBag.mall_Id = 369;
            Thread.Sleep(50);
            _roleSite.CheckCRUD(TempData["SiteMapId"].ToString(), TempData);
            return View();
        }
    }
}
