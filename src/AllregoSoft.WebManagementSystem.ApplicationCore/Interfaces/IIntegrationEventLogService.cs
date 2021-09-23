using AllregoSoft.WebManagementSystem.ApplicationCore.Models;
using AllregoSoft.WebManagementSystem.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IIntegrationEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
        Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction);
        Task MarkEventAsPublishedAsync(Guid eventId);
        Task MarkEventAsInProgressAsync(Guid eventId);
        Task MarkEventAsFailedAsync(Guid eventId);
    }
}
