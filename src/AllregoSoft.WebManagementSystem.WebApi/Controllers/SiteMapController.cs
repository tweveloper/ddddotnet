﻿using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Queries;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    public class SiteMapController : ApiControllerBase
    {
        [HttpGet("[action]")]
        public async Task<List<tbl_SiteMap>> GetRoleSiteMap(long roleId)
        {
            return await Mediator.Send(new GetRoleSiteMapQuery { RoleId = roleId });
        }

        [HttpGet("[action]")]
        public async Task<List<tbl_SiteMap>> SiteMapList()
        {
            return await Mediator.Send(new SiteMapListQuery { });
        }

        [HttpGet("[action]")]
        public async Task<tbl_SiteMap> SiteMapInfo(long Id)
        {
            return await Mediator.Send(new SiteMapInfoQuery { Id = Id });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<string>> UpdateSiteMapInfo(UpdateSiteMapInfoCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> CreateRootNode(CreateRootNodeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> CreateSiteMap(CreateSiteMapCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<string>> ChangePosition(ChangePositionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<string>> DeleteSiteMap(DeleteSiteMapCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
