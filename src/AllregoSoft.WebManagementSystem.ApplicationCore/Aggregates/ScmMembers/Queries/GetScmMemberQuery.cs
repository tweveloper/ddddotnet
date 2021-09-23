using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Queries
{
    public class GetScmMemberQuery : IRequest<tbl_ScmMember>
    {
        public long? ScmMemberId { get; set; }
        public string IdentityId { get; set; }
    }

    public class GetScmMemberQueryHandler : IRequestHandler<GetScmMemberQuery, tbl_ScmMember>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetScmMemberQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<tbl_ScmMember> Handle(GetScmMemberQuery request, CancellationToken cancellationToken)
        {
            if(request.ScmMemberId != null)
            {
                return await _context.tbl_ScmMember.FindAsync(request.ScmMemberId.Value);
            }

            var data = _context.tbl_ScmMember.Where(x => x.IdentityId.Equals(request.IdentityId)).FirstOrDefault();

            return data;
        }
    }
}
