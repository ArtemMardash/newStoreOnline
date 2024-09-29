using MediatR;

namespace Orders.Persistence.DbEntities;

public class EntityDb
{
    public List<INotification> DomainEvents { get; } = new List<INotification>();
}