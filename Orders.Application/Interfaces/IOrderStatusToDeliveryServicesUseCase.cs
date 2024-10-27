using Orders.Domain.Entities;

namespace Orders.Application.Interfaces;

public interface IOrderStatusToDeliveryServicesUseCase
{
    /// <summary>
    /// Method which change status to TransferToDeliveryServices 
    /// </summary>
    Task ExecuteAsync(CancellationToken cancellationToken);
}