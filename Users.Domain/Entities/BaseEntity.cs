using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Users.Domain.Entities;

public class BaseEntity
{
    
    /// <summary>
    /// List of domain events
    /// </summary>
    [NotMapped]
    public List<INotification> DomainEvents { get;} = new List<INotification>();
}