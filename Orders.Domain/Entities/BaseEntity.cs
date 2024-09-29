using MediatR;

namespace Orders.Domain.Entities;

public class BaseEntity
{
    public List<INotification> DomainEvents { get; set; } = new List<INotification>();
}