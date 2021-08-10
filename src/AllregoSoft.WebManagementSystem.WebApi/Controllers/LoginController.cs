using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Entities.DataTransferObject;
using AllregoSoft.WebManagementSystem.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Login(string account, string password)
        {
            var loginDto = new LoginDTO(account, password);
            var item = _loginService.Login(loginDto);
            return Ok(item);
        }
    }
}