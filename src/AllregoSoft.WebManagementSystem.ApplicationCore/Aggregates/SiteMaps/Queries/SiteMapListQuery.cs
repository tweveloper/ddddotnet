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
    public class SiteMapListQuery : IRequest<List<tbl_SiteMap>>
    {

    }

    public class SiteMapListQueryHandler : IRequestHandler<SiteMapListQuery, List<tbl_SiteMap>>
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public SiteMapListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<tbl_SiteMap>> Handle(SiteMapListQuery request, CancellationToken cancellationToken)
        {
            var SiteMapList = await (from x in _context.tbl_SiteMap.Where(x => x.State == "0")
                                     select new tbl_SiteMap
                                     {
                                         Id = x.Id,
                                         Name= x.Name,
                                         Parent = x.Parent, // == 0 ? "#" : x.Parent.ToString(),
                                         Depth = x.Depth,
                                         Position = x.Position,
                                         State = x.State
                                     }).OrderBy(x => x.Depth).ThenBy(x => x.Position).ToListAsync();

            return SiteMapList;
        }
    }
}
