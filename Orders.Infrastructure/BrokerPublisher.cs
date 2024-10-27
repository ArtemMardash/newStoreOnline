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
    
    /// <summary>
    /// Method to publish created order
    /// </summary>
    public async Task PublishOrderCreatedAsync(OrderCreated orderCreated, CancellationToken cancellationToken)
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
            Status = (int) orderCreated.Status
        }, cancellationToken);
    }

    /// <summary>
    /// Method to publish updated order
    /// </summary>
    public async Task PublishOrderUpdatedAsync(OrderUpdated orderUpdated, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IOrderUpdated>(new
        {
            OrderId = orderUpdated.OrderId,
            NewStatus = orderUpdated.NewStatus,
            Products = orderUpdated.Products.Select(p=>new ProductInfo
            {
                PublicId = p.PublicId,
                Price = p.Price,
                Quantity = p.Quantity
            }),
            DeliveryType = orderUpdated.DeliveryType,
            SystemUserId = orderUpdated.SystemUserId,
            PublicUserId = orderUpdated.PublicUserId
        }, cancellationToken);
    }
}