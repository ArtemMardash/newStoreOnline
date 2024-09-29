using MassTransit;
using Orders.Application.Interfaces;
using Orders.Domain.Events;
using SharedKernal;

namespace Order.Infrastructure;

public class BrokerPublisher: IBrokerPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public BrokerPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    public async Task PublishOrderCretedAsync(OrderCreated orderCreated, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IOrderCreated>(new
        {
            SystemId = orderCreated.Id.SystemId,
            PublicId = orderCreated.Id.PublicId,
            Products = orderCreated.Products.Select(p => new ProductInfo
            {
                PublicId = p.PublicId,
                Price = p.Price,
                Quantity = p.Quantity,
            }),
            DeliveryType = orderCreated.DeliveryType,
            Status = orderCreated.Status
        }, cancellationToken);
    }

    public async Task PublishOrderStatusChanged(OrderStatusChanged orderStatusChanged, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IOrderStatusChanged>(new
        {
            OrderId = orderStatusChanged.OrderId,
            NewStatus = orderStatusChanged.NewStatus
        }, cancellationToken);
    }
}