using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.EventHandlers
{
    public class ScmMemberCreatedEventHandler : INotificationHandler<DomainEventNotification<ScmMemberCreatedEvent>>
    {
        private readonly ILogger<ScmMemberCreatedEventHandler> _logger;
        public ScmMemberCreatedEventHandler(ILogger<ScmMemberCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<ScmMemberCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            
            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
