using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Infrastructure.Context;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<tbl_Member, AWMSContext>, IMemberRepository
    {
        public MemberRepository(AWMSContext context) : base(context) { }
    }

    public class MemberTokenRepository : GenericRepository<tbl_MemberToken, AWMSContext>, IMemberTokenRepository
    {
        public MemberTokenRepository(AWMSContext context) : base(context) { }
    }
}
