using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Commands;
using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Queries;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    public class ScmMemberController : ApiControllerBase
    {
        [HttpGet("[action]")]
        public async Task<tbl_ScmMember> GetMemberByIdAsync(string identityId)
        {
            return await Mediator.Send(new GetScmMemberQuery { IdentityId = identityId });
        }

        [HttpGet("{id}")]
        public async Task<tbl_ScmMember> Get(long scmMemberId)
        {
            return await Mediator.Send(new GetScmMemberQuery { ScmMemberId = scmMemberId });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<long>> Create(CreateScmMemberCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
