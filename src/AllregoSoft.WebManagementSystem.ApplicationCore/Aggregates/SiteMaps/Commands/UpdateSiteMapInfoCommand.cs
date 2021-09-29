using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands
{
    public class UpdateSiteMapInfoCommand : IRequest<string>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description{ get; set; }
        public bool Active { get; set; }
    }

    public class UpdateSiteMapInfoCommandHandler : IRequestHandler<UpdateSiteMapInfoCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public UpdateSiteMapInfoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UpdateSiteMapInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.tbl_SiteMap.FindAsync(request.Id);

            entity.Name = request.Name;
            entity.Path = request.Path;
            entity.Description = request.Description;
            entity.Active = request.Active;

            entity.DomainEvents.Add(new UpdateSiteMapInfoCreatedEvent(entity));

            _context.tbl_SiteMap.Update(entity);

            var result = _context.SaveChangesAsync(cancellationToken).Result;

            return Convert.ToBoolean(result).ToString().ToLower();
        }
    }
}