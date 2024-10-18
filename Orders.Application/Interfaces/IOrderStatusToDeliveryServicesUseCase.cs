using Orders.Domain.Entities;

namespace Orders.Application.Interfaces;

public interface IOrderStatusToDeliveryServicesUseCase
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}