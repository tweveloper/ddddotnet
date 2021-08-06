using AllregoSoft.WebManagementSystem.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AllregoSoft.WebManagementSystem.WebApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly Role_SiteMap _roleSite;

        public MemberController(Role_SiteMap RoleSite)
        {
            _roleSite = RoleSite;
        }

        //[UserAuthorizationFilter]
        public IActionResult Index()
        {
            /*
             * SetActive이 실행된 후에 실행하기 위해 Thread.Sleep(50);
             * SetActive에서 TempData["SiteMapId"]를 저장하기 때문
             * */
            Thread.Sleep(50);
            //CRUD 권한 가져오기
            //_roleSite.GetCRUD(TempData["UsrRoleId"].ToString(), TempData["SiteMapId"].ToString(), TempData);
            _roleSite.CheckCRUD(TempData["SiteMapId"].ToString(), TempData);

            return View();
        }

        public ActionResult MemberInfo(int? Id)
        {
            ViewBag.Id = Id;
            //TempData의 전체 데이터 유지
            //TempData.Keep();

            return View();
        }
    }
}