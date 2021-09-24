using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.SiteMaps.EventHandlers
{
    public class SiteMapCompletedEventHandler : INotificationHandler<DomainEventNotification<SiteMapCompletedEvent>>
    {
        private ILogger<SiteMapCompletedEventHandler> _logger;
        public SiteMapCompletedEventHandler(ILogger<SiteMapCompletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<SiteMapCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
