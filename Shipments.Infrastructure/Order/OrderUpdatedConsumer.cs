using MassTransit;
using SharedKernal;
using Shipments.Application.Order.Dtos;
using Shipments.Application.Order.Interfaces;

namespace Shipments.Infrastructure.Order;

public class OrderUpdatedConsumer: IConsumer<IOrderUpdated>
{
    private readonly IOrderUpdatedUseCase _orderUpdatedUseCase;

    public OrderUpdatedConsumer(IOrderUpdatedUseCase orderUpdatedUseCase)
    {
        _orderUpdatedUseCase = orderUpdatedUseCase;
    }
    
    public async Task Consume(ConsumeContext<IOrderUpdated> context)
    {
        var dto = new OrderUpdatedDto
        {
            OrderId = context.Message.OrderId,
            NewStatus = context.Message.NewStatus,
            DeliveryType = context.Message.DeliveryType,
            Products = context.Message.Products.Select(p => new ProductDto
            {
                PublicId = p.PublicId,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList(),
            SystemUserId = context.Message.SystemUserId,
            PublicUserId = context.Message.PublicUserId
        };
        await _orderUpdatedUseCase.ExecuteAsync(dto, CancellationToken.None);
    }
}