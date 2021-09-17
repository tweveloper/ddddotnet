using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Queries
{
    public class GetSiteMapQuery : IRequest<List<tbl_SiteMap>>
    {
        public long MemberId { get; set; }
    }

    public class GetSiteMapQueryHandler : IRequestHandler<GetSiteMapQuery, List<tbl_SiteMap>>
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public GetSiteMapQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;                
        }

        public async Task<List<tbl_SiteMap>> Handle(GetSiteMapQuery request, CancellationToken cancellationToken)
        {
            var list = await (from T1 in _context.tbl_Role
                              join T2 in _context.tbl_Role_Mapping on T1.Id equals T2.RoleId
                              join T3 in _context.tbl_SiteMap on T2.SiteMapId equals T3.Id
                              select T3).ToListAsync();

            return list;
        }
    }
}
