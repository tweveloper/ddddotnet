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

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Queries
{
    public class GetMemberQuery : IRequest<tbl_Member>
    {
        public long? MemberId { get; set; }
        public string IdentityId { get; set; }
    }

    public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, tbl_Member>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMemberQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<tbl_Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            if(request.MemberId != null)
            {
                return await _context.tbl_Member.FindAsync(request.MemberId);
            }
            
            var data = _context.tbl_Member.Where(x => x.IdentityId.Equals(request.IdentityId)).FirstOrDefault();

            return data;
        }
    }
}
