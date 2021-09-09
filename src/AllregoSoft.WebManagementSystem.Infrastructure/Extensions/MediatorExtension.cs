using MediatR;
using AllregoSoft.WebManagementSystem.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using AllregoSoft.WebManagementSystem.Infrastructure.Data;
using AllregoSoft.WebManagementSystem.Domain.Common;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, AwmsDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
