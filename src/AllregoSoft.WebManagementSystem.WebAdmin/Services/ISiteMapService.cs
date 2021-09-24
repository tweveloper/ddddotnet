using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public interface ISiteMapService
    {
        //Task CreateSiteMap(CreateSiteMapCommand command);
        Task<List<tbl_SiteMap>> GetSiteMap(long id);
        //Task<tbl_SiteMap> GetSiteMapByIdentity(string id);
    }
}
