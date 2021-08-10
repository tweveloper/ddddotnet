using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public class RoleRepository : EfCoreRepository<tbl_Role, AWMSContext>, IRoleRepository
    {
        public RoleRepository(AWMSContext context) : base(context) { }
    }
}
