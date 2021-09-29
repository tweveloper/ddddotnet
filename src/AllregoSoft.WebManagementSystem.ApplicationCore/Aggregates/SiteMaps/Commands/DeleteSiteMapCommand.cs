using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands
{
    public class DeleteSiteMapCommand : IRequest<string>
    {
        public long Id { get; set; }
    }

    public class DeleteSiteMapCommandHandler : IRequestHandler<DeleteSiteMapCommand, string>
    {
        private readonly IApplicationDbContext _context;
        public DeleteSiteMapCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteSiteMapCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.tbl_SiteMap.FindAsync(request.Id);

            entity.State = "1";

            entity.DomainEvents.Add(new UpdateSiteMapInfoCreatedEvent(entity));

            _context.tbl_SiteMap.Update(entity);

            var result = _context.SaveChangesAsync(cancellationToken).Result;

            return Convert.ToBoolean(result).ToString().ToLower();
        }
    }
}