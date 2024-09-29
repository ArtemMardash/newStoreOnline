using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain;
using Orders.Domain.Entities;
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
        
    }

    private OrderDb MapDomainToDbEntity(Order order)
    {
        return new OrderDb
        {
            SystemId = order.Id.SystemId,
            PublicId = order.Id.PublicId,
            Products = order.Products.Select(MapDomainToDbEntity).ToList(),
            DeliveryType = (int)order.DeliveryType,
            Status = (int)order.Status,
            SystemUserId = order.UserId.SystemId,
            PublicUserId = order.UserId.PublicId
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