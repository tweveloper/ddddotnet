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

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.Commands
{
    public class CreateScmMemberCommand : IRequest<long>
    {
        public string IdentityId { get; set; }
        public int KeyId { get; set; }
    }

    public class CreateScmMemberCommandHandler : IRequestHandler<CreateScmMemberCommand, long>
    {
        private readonly IApplicationDbContext _context;
        public CreateScmMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateScmMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = new tbl_ScmMember
            {
                IdentityId = request.IdentityId,
                KeyId = request.KeyId
            };

            entity.DomainEvents.Add(new ScmMemberCreatedEvent(entity));

            _context.tbl_ScmMember.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
