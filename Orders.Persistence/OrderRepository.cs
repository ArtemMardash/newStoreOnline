using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain;
using Orders.Domain.Enums;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(MapDomainToDbEntity(order), cancellationToken);
    }

    public async Task CancelAsync(Guid systemId, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.SystemId == systemId, cancellationToken);
        if (order == null)
        {
            throw new InvalidOperationException("There is no order with such Id");
        }

        var status = (OrderStatus)order.Status;
        switch (status)
        {
            case OrderStatus.Unknown:
                throw new InvalidOperationException("Unknown status");
                break;
            case OrderStatus.New:
            case OrderStatus.Assembly:
                order.Status = (int)OrderStatus.Cancelled;
                _context.Orders.Update(order);
                break;
            case OrderStatus.TransferredDeliveryService:
            case OrderStatus.WaitToDelivery:
            case OrderStatus.Delivering:
            case OrderStatus.IssuedToCourier:
            case OrderStatus.Delivered:
                throw new InvalidOperationException($"You can cancel order with status {status}");
        }
    }

    private OrderDb MapDomainToDbEntity(Order order)
    {
        return new OrderDb
        {
            SystemId = order.Id.SystemId,
            PublicId = order.Id.PublicId,
            Products = order.Products.Select(MapDomainToDbEntity).ToList(),
            DeliveryType = (int)order.DeliveryType,
            Status = (int)order.Status
        };
    }

    private ProductDb MapDomainToDbEntity(Product product)
    {
        return new ProductDb
        {
            PublicId = product.PublicId,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }
}