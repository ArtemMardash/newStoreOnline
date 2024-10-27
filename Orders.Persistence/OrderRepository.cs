using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Interfaces;
using Orders.Domain.Entities;
using Orders.Domain.ValueObjects;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to create an order
    /// </summary>
    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(MapDomainToDbEntity(order), cancellationToken);
    }

    /// <summary>
    /// Method to update order
    /// </summary>
    public async Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        var orderDb = await _context.Orders
            .Include(o=>o.Products)
            .FirstOrDefaultAsync(o => o.SystemId == order.Id.SystemId, cancellationToken);
        if (orderDb == null)
        {
            throw new InvalidOperationException("There is no order with such Id");
        }

        orderDb.Status =(int) order.Status;
        orderDb.DomainEvents = order.DomainEvents;
    }

    /// <summary>
    /// Get order by Id 
    /// </summary>
    public async Task<Order> GetOrderByIdAsync(Guid systemId, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(o=>o.Products)
            .FirstOrDefaultAsync(o => o.SystemId == systemId, cancellationToken);
        if (order == null)
        {
            throw new InvalidOperationException("There is no order with such Id");
        }
        return MapDbToDomainEntity(order);
    }

    /// <summary>
    /// Get orders with status assembly
    /// </summary>
    public async  Task<List<Order>> GetOrdersWithStatusAssemblyAsync(CancellationToken cancellationToken)
    {
        var ordersDb = await _context.Orders.Where(o => o.Status == (int) OrderStatus.Assembly).ToListAsync(cancellationToken);
        return ordersDb.Select(MapDbToDomainEntity).ToList();
    }

    /// <summary>
    /// Map domain order to db order
    /// </summary>
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
            PublicUserId = order.UserId.PublicId,
            DomainEvents = order.DomainEvents.ToList()
        };
    }

    /// <summary>
    /// Map domain product to db product
    /// </summary>
    private ProductDb MapDomainToDbEntity(Product product)
    {
        return new ProductDb
        {
            SystemId = product.SystemId,
            PublicId = product.PublicId,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }

    /// <summary>
    /// Map db product to domain product
    /// </summary>
    private Product MapDbToDomainEntity(ProductDb productDb)
    {
        return new Product(productDb.SystemId,productDb.PublicId, productDb.Price, productDb.Quantity);
    }
    
    /// <summary>
    /// Map db order to domain order
    /// </summary>
    private Order MapDbToDomainEntity(OrderDb orderDb)
    {
        return new Order(new OrderId(orderDb.SystemId, orderDb.PublicId), (OrderStatus)orderDb.Status,
            (DeliveryType)orderDb.DeliveryType,
            orderDb.Products.Select(MapDbToDomainEntity).ToList(),
            new UserId(orderDb.SystemUserId, orderDb.PublicUserId));
    }
}