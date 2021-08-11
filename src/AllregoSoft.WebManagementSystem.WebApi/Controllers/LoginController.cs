using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        //private readonly AWMSContext _AWMSContext;

        public LoginController(ILoginService loginService//,
                                //AWMSContext AWMSContext
                                )
        {
            _loginService = loginService;
            //_AWMSContext = AWMSContext;
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] JObject data)
        {
            //var user = _AWMSContext.tbl_Member.Where(x => x.Account.Equals(data["Id"].ToString())).SingleOrDefault();
            //var role = _AWMSContext.tbl_Role.Where(x => x.Id.Equals(user.RoleId)).ToList();

            var loginDto = new LoginDTO(data["Id"].ToString(), data["Password"].ToString());
            var item = _loginService.Login(loginDto);

            return Ok(item);
        }
    }
}