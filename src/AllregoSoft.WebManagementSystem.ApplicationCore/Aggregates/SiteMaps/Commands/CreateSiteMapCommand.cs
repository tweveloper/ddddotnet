using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.Commands
{
    public class CreateSiteMapCommand : IRequest<long>
    {
        //public string IdentityId { get; set; }
        public int RoleId { get; set; }
    }

    public class CreateSiteMapCommandHandler : IRequestHandler<CreateSiteMapCommand, long>
    {
        private readonly IApplicationDbContext _context;
        public CreateSiteMapCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateSiteMapCommand request, CancellationToken cancellationToken)
        {
            var entity = new tbl_SiteMap
            {
                RoleId = request.RoleId
                //IdentityId = request.IdentityId,
                //KeyId = request.KeyId
            };

            entity.DomainEvents.Add(new SiteMapCreatedEvent(entity));

            _context.tbl_SiteMap.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
