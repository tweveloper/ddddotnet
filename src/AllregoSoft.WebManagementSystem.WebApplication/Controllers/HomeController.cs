using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using AllregoSoft.WebManagementSystem.WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly webApiHelper _webApiHelper;

        public HomeController(webApiHelper webApiHelper)
        {
            _webApiHelper = webApiHelper;
        }

        [UserAuthorizationFilter]
        public IActionResult Index()
        {
            string strRecv = "";

            if (_webApiHelper.GetSiteMap(TempData["UsrRoleId"].ToString(), ref strRecv))
            {
                TempData["SiteMap"] = JArray.Parse(strRecv);
            }
            else
            {
                TempData["SiteMap"] = null;
            }

            TempData.Keep();

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NotAuth()
        {
            return View();
        }
    }
}
