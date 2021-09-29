using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Queries
{
    public class SiteMapInfoQuery : IRequest<tbl_SiteMap>
    {
        public long Id { get; set; }
    }

    public class SiteMapInfoQueryHandler : IRequestHandler<SiteMapInfoQuery, tbl_SiteMap>
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public SiteMapInfoQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<tbl_SiteMap> Handle(SiteMapInfoQuery request, CancellationToken cancellationToken)
        {
            var SiteMap = await (from x in _context.tbl_SiteMap.Where(x => x.Id == request.Id && x.State == "0")
                                 select new tbl_SiteMap
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     Parent = x.Parent,
                                     Depth = x.Depth,
                                     Position = x.Position,
                                     Path = x.Path,
                                     Description = x.Description,
                                     Active = x.Active,
                                     State = x.State
                                 }).FirstOrDefaultAsync();

            return SiteMap;
        }
    }
}
