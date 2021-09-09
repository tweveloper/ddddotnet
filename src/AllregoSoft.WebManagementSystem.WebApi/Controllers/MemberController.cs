using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.CreateMember;
using AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Queries;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Controllers
{
    [Authorize]
    public class MemberController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<tbl_Member> GetMemberByIdAsync(long id)
        {
            //var userName = IdentityService.GetUserName();
            //var identity = IdentityService.GetUserIdentity();
            return await Mediator.Send(new GetMemberQuery { MemberId = id });
        }

        //[HttpGet("{id}")]
        //public async Task<tbl_Member> GetMemberByIdentityIdAsync(Guid id)
        //{
        //    //var userName = IdentityService.GetUserName();
        //    //var identity = IdentityService.GetUserIdentity();
        //    return await Mediator.Send(new GetMemberQuery { IdentityId = id });
        //}

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateMemberCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
