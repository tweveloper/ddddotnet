using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.CreateMember
{
    public class CreateMemberCommand : IRequest<long>
    {
        public string Account { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid IdentityId { get; set; }
    }

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateMemberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = new tbl_Member
            {
                Account = request.Account,
                Password = request.Password,
                Name = request.Name,
                Email = request.Email,
                UseYN = "Y",
                IdentityId = request.IdentityId
            };

            entity.DomainEvents.Add(new MemberCreatedEvent(entity));

            _context.tbl_Member.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
