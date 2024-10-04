using Orders.Domain.Events;

namespace Orders.Application.Interfaces;

public interface IBrokerPublisher
{
    Task PublishOrderCretedAsync(OrderCreated orderCreated, CancellationToken cancellationToken);

    Task PublishOrderUpdated(OrderUpdated orderUpdated, CancellationToken cancellationToken);
}