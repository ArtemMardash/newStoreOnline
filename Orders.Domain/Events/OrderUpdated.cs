using MediatR;
using Orders.Domain.Entities;

namespace Orders.Domain.Events;

public class OrderUpdated: INotification
{
    /// <summary>
    /// Order Id 
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// New status of order
    /// </summary>
    public int NewStatus { get; set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<Product> Products { get; set; }
    
    /// <summary>
    /// Delivery type of order
    /// </summary>
    public int DeliveryType { get; set; }
    
    /// <summary>
    /// User Id 
    /// </summary>
    public Guid SystemUserId { get; set; }
    
    /// <summary>
    /// User public Id
    /// </summary>
    public string PublicUserId { get; set; }
}