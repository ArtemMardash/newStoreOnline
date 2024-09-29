using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.Enums;
using Orders.Domain.ValueObjects;

namespace Orders.Domain.Events;

public class OrderCreated: INotification
{
    public OrderId Id { get; set; }
    
    public List<Product> Products { get; set; } 
    
    public DeliveryType DeliveryType { get; set; }
    
    public OrderStatus Status { get; set; }
}