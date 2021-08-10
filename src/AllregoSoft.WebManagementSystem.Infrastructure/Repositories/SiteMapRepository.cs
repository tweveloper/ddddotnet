using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public class SiteMapRepository : GenericRepository<tbl_SiteMap, AWMSContext>, ISiteMapRepository
    {
        public SiteMapRepository(AWMSContext context) : base(context) { }
    }
}
