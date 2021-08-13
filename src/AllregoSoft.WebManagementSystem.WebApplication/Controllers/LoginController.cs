using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly webApiHelper _webApiHelper;
        private readonly Role_SiteMap _roleSite;

        public LoginController()
        {
            _webApiHelper = new webApiHelper();
            _roleSite = new Role_SiteMap(_webApiHelper);
        }

        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl ?? "/";
            return View();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginProc([FromBody] JObject data)
        {
            string strRecv = "";
            var jRetObj = new JObject();

            if (_webApiHelper.Login(data["Id"].ToString(), data["Pwd"].ToString(), ref strRecv))
            {
                jRetObj = JObject.Parse(strRecv);
                TempData["UsrId"] = Convert.ToInt64(jRetObj["MemId"]);
                //TempData["UsrApiId"] = Convert.ToInt32(jRetObj["ApiId"]);
                TempData["UsrRoleId"] = Convert.ToInt64(jRetObj["RoleId"]);
                //TempData["UsrAccount"] = Account;
                //TempData["UsrPassword"] = data["Pwd"].ToString();
                //TempData["RoleName"] = Util.GetJsonParse(strRecv, "RoleNm");
                //TempData["UsrName"] = jRetObj["Name"].ToString();
                //ConstantHelper.Password = jRetObj["Password"].ToString();

                if (_webApiHelper.GetSiteMap(TempData["UsrRoleId"].ToString(), ref strRecv))
                {
                    TempData["SiteMap"] = JArray.Parse(strRecv);
                }
                else
                {
                    TempData["SiteMap"] = null;
                }
                TempData.Keep();

                _roleSite.GetCRUD(TempData["UsrRoleId"].ToString(), TempData);
                jRetObj.Add("result", "true");
            }
            else
            {
                jRetObj.Add("result", "false");
                jRetObj.Add("msg", strRecv);
            }
            return Json(jRetObj);
        }
    }
}
