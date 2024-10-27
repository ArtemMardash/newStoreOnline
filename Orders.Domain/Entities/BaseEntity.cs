using MediatR;

namespace Orders.Domain.Entities;

public class BaseEntity
{
    /// <summary>
    /// List of events to publish
    /// </summary>
    public List<INotification> DomainEvents { get; set; } = new List<INotification>();
}