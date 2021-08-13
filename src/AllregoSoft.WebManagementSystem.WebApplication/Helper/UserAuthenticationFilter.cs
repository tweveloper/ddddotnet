using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.WebApplication.Controllers;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Security.Claims;

namespace AllregoSoft.WebManagementSystem.WebApplication.Filters
{
    public class UserAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            webApiHelper Api = new webApiHelper();
            Role_SiteMap _roleSite = new Role_SiteMap(Api);

            var controller = filterContext.Controller as Controller;
            var TempData = controller.TempData;
            /* 컨트롤러에서 [AllowAnonymous] 사용하기 위해(권한없이 볼 수 있도록)
             * [AllowAnonymous]를 사용한 함수는 allowanyone 값이 true
             * 그럼 method는 어찌할...? 하드코딩...?
             * */
            var cad = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filterContext.ActionDescriptor;
            var allow = cad.ControllerTypeInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any() || cad.MethodInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any();
            //예외 경로 추가
            string[] ExName = new string[] { "/Member/MemberInfo" };
            string CtrlName = controller.ControllerContext.RouteData.Values["controller"].ToString();
            string ActName = controller.ControllerContext.RouteData.Values["action"].ToString();

            if (TempData["UsrRoleId"] == null)
            {
                if (!allow)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new
                        {
                            action = "Index",
                            controller = "Login",
                            returnUrl = filterContext.HttpContext.Request.Path
                        }));
                }
            }
            else
            {
                if (TempData["AllCRUD"] != null)
                {
                    bool value = false;

                    foreach (string path in ExName)
                    {
                        if (path.Equals("/" + CtrlName + "/" + ActName))
                        {
                            value = true;
                            break;
                        }
                    }

                    if (!value)
                    {
                        if (!_roleSite.CheckAuth(filterContext.HttpContext.Request.Path, TempData) && filterContext.HttpContext.Request.Path != "/")
                        {
                            if (!allow)
                            {
                                _roleSite.SetActive("0", TempData);
                                filterContext.Result = new RedirectResult("/Home/NotAuth");
                            }
                        }
                    }
                    else
                    {
                        _roleSite.CheckAuth("/" + CtrlName, TempData);

                        if (string.IsNullOrEmpty(TempData["U"].ToString()))
                        {
                            filterContext.Result = new RedirectResult("/Home/NotAuth");
                        }
                    }
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new
                        {
                            action = "Index",
                            controller = "Login",
                            returnUrl = filterContext.HttpContext.Request.Path
                        }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}