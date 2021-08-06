using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using AllregoSoft.WebManagementSystem.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly webApiHelper _webApiHelper;
        private readonly Role_SiteMap _roleSite;

        public HomeController(webApiHelper webApiHelper, Role_SiteMap RoleSite)
        {
            _webApiHelper = webApiHelper;
            _roleSite = RoleSite;
        }

        //[UserAuthorizationFilter]
        public IActionResult Index()
        {
            //TempData["UsrRoleId"] 강제 설정, 로그인할 때 받아오면 됨
            if (TempData["UsrRoleId"] == null)
                TempData["UsrRoleId"] = "1";
            //GetSiteMap 호출하여 TempData["SiteMap"]에 메뉴(SiteMap) 데이터 저장

            string strRecv = "";

            //if (_webApiHelper.GetSiteMap(HttpContext.Session.GetInt32("UsrRoleId").ToString(), ref strRecv))
            if (_webApiHelper.GetSiteMap(TempData["UsrRoleId"].ToString(), ref strRecv))
            {
                TempData["SiteMap"] = JArray.Parse(strRecv);
            }
            else
            {
                TempData["SiteMap"] = null;
            }

            _roleSite.GetCRUD(TempData["UsrRoleId"].ToString(), TempData);
            //TempData["SiteMap"] 데이터 유지
            //TempData.Keep("SiteMap");
            //TempData["UsrRoleId"] 데이터 유지
            //TempData.Keep("UsrRoleId");
            TempData.Keep();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
