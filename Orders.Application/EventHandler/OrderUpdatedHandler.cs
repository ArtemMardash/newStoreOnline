using MediatR;
using Orders.Application.Interfaces;
using Orders.Domain.Events;

namespace Orders.Application.EventHandler;

public class OrderUpdatedHandler: INotificationHandler<OrderUpdated>
{
    private readonly IBrokerPublisher _brokerPublisher;

    public OrderUpdatedHandler(IBrokerPublisher brokerPublisher)
    {
        _brokerPublisher = brokerPublisher;
    }
    
    /// <summary>
    /// Nethod to publish about edited order
    /// </summary>
    public Task Handle(OrderUpdated notification, CancellationToken cancellationToken)
    {
        return _brokerPublisher.PublishOrderUpdatedAsync(notification, cancellationToken);
    }
}