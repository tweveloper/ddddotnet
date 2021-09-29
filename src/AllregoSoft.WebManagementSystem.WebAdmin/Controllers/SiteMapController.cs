using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Controllers
{
    //[Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class SiteMapController : BaseController
    {
        private readonly ISiteMapService _siteMapService;
        private readonly ILogger<SiteMapController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SiteMapController(
            ILogger<SiteMapController> logger,
            ISiteMapService siteMapService,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _siteMapService = siteMapService;
            _httpContextAccessor = httpContextAccessor;
        } 

        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask;
            return View();
        }

        public Task<List<tbl_SiteMap>> SiteMapList()
        {
            return _siteMapService.SiteMapList();
        }

        public Task<tbl_SiteMap> SiteMapInfo(long Id)
        {
            return _siteMapService.SiteMapInfo(Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSiteMapInfo([FromBody] UpdateSiteMapInfoCommand command)
        {
            var result = await _siteMapService.UpdateSiteMapInfo(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRootNode([FromBody] CreateRootNodeCommand command)
        {
            var result = await _siteMapService.CreateRootNode(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ChangePosition([FromBody] ChangePositionCommand command)
        {
            var result = await _siteMapService.ChangePosition(command);
            return Ok(result);
        }
    }
}