using AllregoSoft.WebManagementSystem.WebApplication.Controllers;
using AllregoSoft.WebManagementSystem.WebApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace AllregoSoft.WebManagementSystem.WebApplication.Filters
{
    public class UserAuthorizationFilter : ActionFilterAttribute//, IAuthorizationFilter
    {
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    string UsrRoleId = context.HttpContext.Session.GetInt32("UsrRoleId").ToString();

        //    if (string.IsNullOrEmpty(UsrRoleId))
        //    {
        //        context.Result = new RedirectToRouteResult(
        //            new RouteValueDictionary(new
        //            {
        //                action = "Index",
        //                controller = "Login"//,
        //                //returnUrl = context.HttpContext.Request.Path
        //            }));
        //    }
        //    else
        //    {
        //        var MetaData = context.Filters[1].GetType();
        //        var temp = MetaData.CustomAttributes.GetType();
        //        //var Temp = new TempDataDictionaryFactory();
        //        //var TempData = new TempDataDictionary(context.HttpContext, temp.);
        //        return;
        //        //context.Result = new RedirectToRouteResult(
        //        //    new RouteValueDictionary(new
        //        //    {
        //        //        action = "Index",
        //        //        controller = "Home"
        //        //    }));
        //    }
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            webApiHelper Api = new webApiHelper();
            Role_SiteMap _roleSite = new Role_SiteMap(Api);

            var controller = filterContext.Controller as Controller;
            var TempData = controller.TempData;

            if (TempData["UsrRoleId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "Login",
                        returnUrl = filterContext.HttpContext.Request.Path
                    }));
            }
            else
            {
                if (TempData["SiteMapId"] != null)
                {
                    //_roleSite.GetCRUD(TempData["UsrRoleId"].ToString(), TempData["SiteMapId"].ToString(), TempData);
                    _roleSite.GetCRUD(TempData["UsrRoleId"].ToString(), TempData);
                    //return;
                }
            }
        }
    }
}