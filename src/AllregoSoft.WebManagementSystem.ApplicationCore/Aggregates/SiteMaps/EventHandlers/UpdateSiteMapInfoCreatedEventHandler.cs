using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.EventHandlers
{
    public class UpdateSiteMapInfoCreatedEventHandler : INotificationHandler<DomainEventNotification<UpdateSiteMapInfoCreatedEvent>>
    {
        private readonly ILogger<UpdateSiteMapInfoCreatedEventHandler> _logger;
        public UpdateSiteMapInfoCreatedEventHandler(ILogger<UpdateSiteMapInfoCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<UpdateSiteMapInfoCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            
            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
