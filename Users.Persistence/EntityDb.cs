using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Users.Persistence;

public class EntityDb
{
    [NotMapped]
    public List<INotification> DomainEvents { get; set; } = new List<INotification>();
}