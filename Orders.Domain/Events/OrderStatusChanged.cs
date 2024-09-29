using MediatR;

namespace Orders.Domain.Events;

public class OrderStatusChanged: INotification
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
}