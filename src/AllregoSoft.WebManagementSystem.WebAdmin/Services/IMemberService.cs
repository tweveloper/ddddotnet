using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.CreateMember;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.WebAdmin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Services
{
    public interface IMemberService
    {
        Task<tbl_Member> GetMember(long id);
        Task<tbl_Member> GetMemberByIdentity(string id);
        Task<string> CreateAuthentication(RegisterViewModel model);
        Task CreateMember(CreateMemberCommand command);
    }
}
