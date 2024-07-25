using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Billing.Persistence.EntitiesDb;

public class BaseEntity
{
    
    /// <summary>
    /// List of notification  
    /// </summary>
    [NotMapped]
    public List<INotification> DomainEvents { get;} = new List<INotification>();
}