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
    public class UpdateSiteMapInfoCompletedEventHandler : INotificationHandler<DomainEventNotification<UpdateSiteMapInfoCompletedEvent>>
    {
        private ILogger<UpdateSiteMapInfoCompletedEventHandler> _logger;
        public UpdateSiteMapInfoCompletedEventHandler(ILogger<UpdateSiteMapInfoCompletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<UpdateSiteMapInfoCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
