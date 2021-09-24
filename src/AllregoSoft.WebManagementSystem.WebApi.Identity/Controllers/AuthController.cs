using AllregoSoft.WebManagementSystem.WebApi.Identity.Models;
using AllregoSoft.WebManagementSystem.WebApi.Identity.Models.AccountViewModels;
using AutoMapper.Configuration;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Controllers
{
    [Authorize("Admin")]
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public IActionResult Get(string account)
        {
            var userId = _userManager.FindByIdAsync(account);
            return Ok(userId);
        }

        // POST: /api/auth/create
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] AuthViewModel model)
        {
            var user = new ApplicationUser
            {
                Account = model.Account,
                UserName = model.Name,
                Email = model.Email,
            };
            // TODO : 비밀번호 초기값으로 할지 받을지 추후 변경
            // 일단 초기 비밀번호로 진행
            //var result = await _userManager.CreateAsync(user, model.Password);
            var result = await _userManager.CreateAsync(user, "Pa$$word");
            if (result.Errors.Count() > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(user);
        }
    }
}
