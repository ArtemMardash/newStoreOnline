using MediatR;

namespace Orders.Persistence.DbEntities;

public class BaseEntity
{
    public List<INotification> DomainEvents { get; } = new List<INotification>();
}