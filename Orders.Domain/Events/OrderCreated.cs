using Common.Enums;
using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.ValueObjects;

namespace Orders.Domain.Events;

public class OrderCreated: INotification
{
    /// <summary>
    /// Id of order
    /// </summary>
    public OrderId Id { get; set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<Product> Products { get; set; } 
    
    /// <summary>
    /// Delivery type of product
    /// </summary>
    public DeliveryType DeliveryType { get; set; }
    
    /// <summary>
    /// Status of order
    /// </summary>
    public OrderStatus Status { get; set; }
}