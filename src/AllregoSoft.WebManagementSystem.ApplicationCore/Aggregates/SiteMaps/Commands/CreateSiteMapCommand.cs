using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands
{
    public class CreateSiteMapCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public int Depth { get; set; }
    }

    public class CreateSiteMapCommandHandler : IRequestHandler<CreateSiteMapCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public CreateSiteMapCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateSiteMapCommand request, CancellationToken cancellationToken)
        {
            long? parent = request.Parent == "#" ? 0 : Convert.ToInt64(request.Parent);
            int position = 1;
            var sitemap = await _context.tbl_SiteMap.Where(x => x.Depth == request.Depth && x.Parent == parent && x.State == "0").ToListAsync();
            
            if(sitemap.Count > 0)
            {
                position = sitemap.Max(x => x.Position) + 1;
            }

            var entity = new tbl_SiteMap
            {
                Name = request.Name,
                Parent = parent,
                Depth = request.Depth,
                Position = position,
                Active = false,
                State = "0"
            };

            entity.DomainEvents.Add(new CreateSiteMapCreatedEvent(entity));

            await _context.tbl_SiteMap.AddAsync(entity);

            var result = _context.SaveChangesAsync(cancellationToken).Result;

            return Convert.ToBoolean(result).ToString().ToLower();
        }
    }
}
