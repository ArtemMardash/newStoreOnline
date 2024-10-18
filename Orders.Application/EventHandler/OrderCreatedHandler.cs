using MediatR;
using Orders.Application.Interfaces;
using Orders.Domain.Events;

namespace Orders.Application.EventHandler;

public class OrderCreatedHandler: INotificationHandler<OrderCreated>
{
    private readonly IBrokerPublisher _brokerPublisher;

    public OrderCreatedHandler(IBrokerPublisher brokerPublisher)
    {
        _brokerPublisher = brokerPublisher;
    }
    public Task Handle(OrderCreated notification, CancellationToken cancellationToken)
    {
        return _brokerPublisher.PublishOrderCreatedAsync(notification, cancellationToken);
    }
}