using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Commands;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public interface IScmMemberService
    {
        Task CreateScmMember(CreateScmMemberCommand command);
        Task<tbl_ScmMember> GetScmMember(long id);
        Task<tbl_ScmMember> GetScmMemberByIdentity(string id);
    }
}
