using System.Diagnostics;
using Common.Enums;
using Orders.Domain.Events;
using Orders.Domain.ValueObjects;
using SharedKernal;

namespace Orders.Domain.Entities;

public class Order: BaseEntity
{
    
    /// <summary>
    /// Order Id 
    /// </summary>
    public OrderId Id { get; private set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<Product> Products { get; private set; } 
    
    /// <summary>
    /// Delivery type pf order
    /// </summary>
    public DeliveryType DeliveryType { get; private set; }
    
    /// <summary>
    /// Status of order
    /// </summary>
    public OrderStatus Status { get; private set; }
    
    /// <summary>
    /// User Id of order
    /// </summary>
    public UserId UserId { get; private set; }

    public Order(OrderId id, OrderStatus status ,DeliveryType deliveryType, List<Product> products, UserId userId)
    {
        Id = id;
        Status = status;
        DeliveryType = deliveryType;
        Products = products;
        UserId = userId;
    }

    public Order(DeliveryType deliveryType, List<Product> products, UserId userId )
    {
        var publicPart = new string (DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString().Reverse().ToArray()).Substring(0,4); 
        Id = new OrderId(Guid.NewGuid(),
            PublicIdGenerator.Generate("ord", int.Parse(publicPart)));
        DeliveryType = deliveryType;
        Status = OrderStatus.New;
        Products = products;
        UserId = userId;
        DomainEvents.Add(new OrderCreated
        {
            Id = Id,
            Products = Products,
            DeliveryType = DeliveryType,
            Status = Status
        });
    }

    /// <summary>
    /// Logic to set status correctly 
    /// </summary>
    public void SetStatus(OrderStatus newStatus)
    {
        switch (Status)
        {
            case OrderStatus.New when newStatus is OrderStatus.WaitToPayment or OrderStatus.Cancelled:
                Status = newStatus;
                break;
            case OrderStatus.WaitToPayment when newStatus is OrderStatus.Assembly or OrderStatus.Cancelled:
                Status = newStatus;
                break;
            case OrderStatus.Assembly when newStatus is OrderStatus.TransferredDeliveryService:
                Status = newStatus;
                break;
            case OrderStatus.TransferredDeliveryService when newStatus is OrderStatus.WaitToDelivery:
                Status = newStatus;
                break;
            case OrderStatus.WaitToDelivery when newStatus is OrderStatus.Delivering:
                Status = newStatus;
                break;
            case OrderStatus.Delivering when newStatus is OrderStatus.IssuedToCourier or OrderStatus.Delivered or OrderStatus.Rejected:
                Status = newStatus;
                break;
            case OrderStatus.IssuedToCourier when newStatus is OrderStatus.Delivered or OrderStatus.Rejected:
                Status = newStatus;
                break;
            default:
                throw new InvalidOperationException($"{Status} can not be changes to {newStatus}");
        }
        DomainEvents.Add(new OrderUpdated
        {
            OrderId = Id.SystemId,
            NewStatus = (int) newStatus,
            Products = Products,
            DeliveryType = (int) DeliveryType,
            PublicUserId = UserId.PublicId,
            SystemUserId = UserId.SystemId
        });
        
    }

}