using Orders.Domain;
using Orders.Domain.Entities;

namespace Orders.Application.Interfaces;

public interface IOrderRepository
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task CancelAsync(Guid systemId, CancellationToken cancellationToken);
}