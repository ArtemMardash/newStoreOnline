using Orders.Domain;

namespace Orders.Appliaction.Interfaces;

public interface IOrderRepository
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task CancelleAsync(string publicId, CancellationToken cancellationToken);
}