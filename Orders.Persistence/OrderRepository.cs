using Microsoft.EntityFrameworkCore;
using Orders.Appliaction.Interfaces;
using Orders.Domain;
using Orders.Domain.Enums;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class OrderRepository: IOrderRepository
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

    public async Task CancelleAsync(string publicId, CancellationToken cancellationToken)
    {
        var order =await _context.Orders.FirstOrDefaultAsync(o => o.PublicId == publicId, cancellationToken);
        order.Status = (int)OrderStatus.Canceled;
        _context.Orders.Update(order);
    }

    private OrderDb MapDomainToDbEntity(Order order)
    {
        return new OrderDb
        {
            SystemId = order.Id.SystemId,
            PublicId = order.Id.PublicId,
            Products = _context.Products.ToList(),
            DeliveryType = (int)order.DeliveryType,
            Status = (int)order.Status
        };
    }
}