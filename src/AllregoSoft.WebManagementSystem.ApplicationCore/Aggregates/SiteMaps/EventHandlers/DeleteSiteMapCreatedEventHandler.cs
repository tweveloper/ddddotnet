using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.EventHandlers
{
    public class DeleteSiteMapCreatedEventHandler : INotificationHandler<DomainEventNotification<DeleteSiteMapCreatedEvent>>
    {
        private readonly ILogger<DeleteSiteMapCreatedEventHandler> _logger;
        public DeleteSiteMapCreatedEventHandler(ILogger<DeleteSiteMapCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<DeleteSiteMapCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            
            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
