using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public class RoleMappingRepository : EfCoreRepository<tbl_Role_Mapping, AWMSContext>, IRoleMappingRepository
    {
        public RoleMappingRepository(AWMSContext context) : base(context) { }
    }
}
