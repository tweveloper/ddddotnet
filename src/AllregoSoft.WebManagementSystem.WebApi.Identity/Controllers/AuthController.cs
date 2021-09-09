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
        public IActionResult Get()
        {
            return Ok();
        }

        //
        // POST: /api/auth/create
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                Account = model.Email,
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Errors.Count() > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(user);
        }
    }
}
