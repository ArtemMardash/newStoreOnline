using Orders.Domain;
using Orders.Domain.Entities;

namespace Orders.Application.Interfaces;

public interface IOrderRepository
{
    /// <summary>
    /// Method to create a new order
    /// </summary>
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    /// <summary>
    /// Method to update an order
    /// </summary>
    Task UpdateAsync(Order order, CancellationToken cancellationToken);

    /// <summary>
    /// Method to get an order  by Id
    /// </summary>
    Task<Order> GetOrderByIdAsync(Guid systemId, CancellationToken cancellationToken);

    /// <summary>
    /// Method to get orders with status assembly
    /// </summary>
    Task<List<Order>> GetOrdersWithStatusAssemblyAsync(CancellationToken cancellationToken);
}