using Orders.Domain.Enums;
using Orders.Domain.ValueObjects;
using SharedKernal;

namespace Orders.Domain;

public class Order
{
    public OrderId Id { get; set; }
    
    public List<Product> Products { get; set; } 
    
    public DeliveryType DeliveryType { get; set; }

    /// <summary>
    /// Status of order по умолчанию должен быть new
    /// </summary>
    public OrderStatus Status { get; set; }

    public Order(OrderId id, OrderStatus status ,DeliveryType deliveryType)
    {
        Id = id;
        Status = status;
        DeliveryType = deliveryType;
    }

    public Order(DeliveryType deliveryType)
    {
        var publicPart = new string (DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString().Reverse().ToArray()).Substring(0,4); 
        Id = new OrderId(Guid.NewGuid(),
            PublicIdGenerator.Generate("ord", int.Parse(publicPart)));
        DeliveryType = deliveryType;
        Status = OrderStatus.New;
    }

}