using MediatR;
using Orders.Domain.Entities;

namespace Orders.Domain.Events;

public class OrderUpdated: INotification
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
    
    public List<Product> Products { get; set; }
    
    public int DeliveryType { get; set; }
    
    public Guid SystemUserId { get; set; }
    
    public string PublicUserId { get; set; }
}