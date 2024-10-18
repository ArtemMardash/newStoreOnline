using Orders.Domain;
using Orders.Domain.Entities;

namespace Orders.Application.Interfaces;

public interface IOrderRepository
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task UpdateAsync(Order order, CancellationToken cancellationToken);

    Task<Order> GetOrderByIdAsync(Guid systemId, CancellationToken cancellationToken);

    Task<List<Order>> GetOrdersWithStatusAssemblyAsync(CancellationToken cancellationToken);
}