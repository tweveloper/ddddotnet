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
    public class CreateRootNodeCommand : IRequest<string>
    {
        public string Name { get; set; }
    }

    public class CreateRootNodeCommandHandler : IRequestHandler<CreateRootNodeCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public CreateRootNodeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateRootNodeCommand request, CancellationToken cancellationToken)
        {
            int position = 1;
            var sitemap = await _context.tbl_SiteMap.Where(x => x.Depth == 1 && x.State == "0").ToListAsync();

            if (sitemap.Count > 0)
            {
                position = sitemap.Max(x => x.Position) + 1;
            }

            var entity = new tbl_SiteMap
            {
                Name = request.Name,
                Parent = 0,
                Depth = 1,
                State = "0",
                Active = false,
                Position = position
            };

            entity.DomainEvents.Add(new CreateRootNodeCreatedEvent(entity));

            await _context.tbl_SiteMap.AddAsync(entity);

            var result = _context.SaveChangesAsync(cancellationToken).Result;

            return Convert.ToBoolean(result).ToString().ToLower();
        }
    }
}