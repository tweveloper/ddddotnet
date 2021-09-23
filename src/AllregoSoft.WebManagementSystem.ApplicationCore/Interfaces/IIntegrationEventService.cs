using AllregoSoft.WebManagementSystem.Domain.Common;
using System;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
