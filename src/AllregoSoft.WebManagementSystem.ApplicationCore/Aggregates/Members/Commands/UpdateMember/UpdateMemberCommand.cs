using AllregoSoft.WebManagementSystem.ApplicationCore.Exceptions;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.Members.Commands.UpdateMember
{
    public class UpdateMemberCommand : IRequest
    {
        public long Id { get; set; }
        public string UseYn { get; set; }
    }

    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMemberCommandHandler(IApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.tbl_Member.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(tbl_Member), request.Id);
            }

            entity.UseYn = request.UseYn;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
