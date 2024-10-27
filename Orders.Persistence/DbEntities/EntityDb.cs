using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Orders.Persistence.DbEntities;

public class EntityDb
{
    /// <summary>
    /// List of domain events
    /// </summary>
    [NotMapped]
    public List<INotification> DomainEvents { get; set; } = new List<INotification>();
}