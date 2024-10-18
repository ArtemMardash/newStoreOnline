using Orders.Domain.Events;

namespace Orders.Application.Interfaces;

public interface IBrokerPublisher
{
    Task PublishOrderCreatedAsync(OrderCreated orderCreated, CancellationToken cancellationToken);

    Task PublishOrderUpdatedAsync(OrderUpdated orderUpdated, CancellationToken cancellationToken);
}