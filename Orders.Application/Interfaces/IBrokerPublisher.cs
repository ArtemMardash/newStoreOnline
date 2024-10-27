using Orders.Domain.Events;

namespace Orders.Application.Interfaces;

public interface IBrokerPublisher
{
    /// <summary>
    /// Method to publish  when order created
    /// </summary>
    Task PublishOrderCreatedAsync(OrderCreated orderCreated, CancellationToken cancellationToken);

    /// <summary>
    /// Method to publish when order updated
    /// </summary>
    /// <param name="orderUpdated"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PublishOrderUpdatedAsync(OrderUpdated orderUpdated, CancellationToken cancellationToken);
}