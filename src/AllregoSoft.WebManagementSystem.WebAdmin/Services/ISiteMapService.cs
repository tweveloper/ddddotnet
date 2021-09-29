using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public interface ISiteMapService
    {
        Task<List<tbl_SiteMap>> GetRoleSiteMap(long id);
        Task<List<tbl_SiteMap>> SiteMapList();
        Task<tbl_SiteMap> SiteMapInfo(long id);
        Task<string> UpdateSiteMapInfo(UpdateSiteMapInfoCommand command);
        Task<string> CreateRootNode(CreateRootNodeCommand command);
        Task<string> ChangePosition(ChangePositionCommand command);
    }
}
