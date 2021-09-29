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
    public class GetRoleSiteMapQuery : IRequest<List<tbl_SiteMap>>
    {
        public long RoleId { get; set; }
    }

    public class GetRoleSiteMapQueryHandler : IRequestHandler<GetRoleSiteMapQuery, List<tbl_SiteMap>>
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public GetRoleSiteMapQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<tbl_SiteMap>> Handle(GetRoleSiteMapQuery request, CancellationToken cancellationToken)
        {
            var SiteMap = await (from x in _context.tbl_Role_Mapping.Where(x => x.RoleId == request.RoleId)
                                 join a in _context.tbl_SiteMap.Where(a => a.State == "0" && a.Active == true && a.Parent == 0) on x.SiteMapId equals a.Id
                                 select new tbl_SiteMap
                                 {
                                     Id = a.Id,
                                     Name = a.Name,
                                     Parent = a.Parent,
                                     Depth = a.Depth,
                                     Position = a.Position,
                                     Path = a.Path,
                                     Description = a.Description,
                                     State = a.State,
                                     Active = a.Active,
                                     Clicked = a.Clicked,
                                     //ParentMap = a.ParentMap,
                                     ChildMaps = (from y in _context.tbl_Role_Mapping.Where(y => y.RoleId == request.RoleId)
                                                  join b in a.ChildMaps.Where(b => b.State == "0" && b.Active == true) on y.SiteMapId equals b.Id
                                                  select new tbl_SiteMap
                                                  {
                                                      Id = b.Id,
                                                      Name = b.Name,
                                                      Parent = b.Parent,
                                                      Depth = b.Depth,
                                                      Position = b.Position,
                                                      Path = b.Path,
                                                      Description = b.Description,
                                                      State = b.State,
                                                      Active = b.Active,
                                                      Clicked = b.Clicked,
                                                      ParentMap = b.ParentMap,
                                                      ChildMaps = (from z in _context.tbl_Role_Mapping.Where(z => z.RoleId == request.RoleId)
                                                                   join c in b.ChildMaps.Where(c => c.State == "0" && c.Active == true) on z.SiteMapId equals c.Id
                                                                   select new tbl_SiteMap
                                                                   {
                                                                       Id = c.Id,
                                                                       Name = c.Name,
                                                                       Parent = c.Parent,
                                                                       Depth = c.Depth,
                                                                       Position = c.Position,
                                                                       Path = c.Path,
                                                                       Description = c.Description,
                                                                       State = c.State,
                                                                       Active = c.Active,
                                                                       Clicked = c.Clicked,
                                                                       ParentMap = c.ParentMap
                                                                   }).OrderBy(c => c.Position).ToList()
                                                  }).OrderBy(b => b.Position).ToList()
                                 }).OrderBy(a => a.Position).ToListAsync();

            return SiteMap;
        }
    }
}
