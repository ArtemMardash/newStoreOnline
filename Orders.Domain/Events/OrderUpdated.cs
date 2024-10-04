using MediatR;

namespace Orders.Domain.Events;

public class OrderUpdated: INotification
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
}