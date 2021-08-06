using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public class MemberRepository : EfCoreRepository<tbl_Member, AWMSContext>, IMemberRepository
    {
        public MemberRepository(AWMSContext context) : base(context) { }
    }
}
