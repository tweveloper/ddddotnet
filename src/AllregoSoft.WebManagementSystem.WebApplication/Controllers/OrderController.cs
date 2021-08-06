using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly Role_SiteMap _roleSite;

        public OrderController(Role_SiteMap RoleSite)
        {
            _roleSite = RoleSite;
        }

        public IActionResult OrderList()
        {
            Thread.Sleep(50);
            _roleSite.CheckCRUD(TempData["SiteMapId"].ToString(), TempData);
            ViewBag.mall_Id = 369;
            return View();
        }
    }
}
