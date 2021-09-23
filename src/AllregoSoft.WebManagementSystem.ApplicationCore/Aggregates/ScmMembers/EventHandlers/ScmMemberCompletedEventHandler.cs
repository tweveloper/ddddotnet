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

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Aggregates.ScmMembers.EventHandlers
{
    public class ScmMemberCompletedEventHandler : INotificationHandler<DomainEventNotification<ScmMemberCompletedEvent>>
    {
        private ILogger<ScmMemberCompletedEventHandler> _logger;
        public ScmMemberCompletedEventHandler(ILogger<ScmMemberCompletedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<ScmMemberCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("AWMS Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
