using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.EventHandlers
{
    public class SiteMapCreatedEventHandler : INotificationHandler<DomainEventNotification<SiteMapCreatedEvent>>
    {
        private readonly ILogger<SiteMapCreatedEventHandler> _logger;
        public SiteMapCreatedEventHandler(ILogger<SiteMapCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<SiteMapCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            
            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
