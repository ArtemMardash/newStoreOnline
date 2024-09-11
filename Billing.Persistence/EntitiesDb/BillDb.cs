using Billing.Domain;

namespace Billing.Persistence.EntitiesDb;

public class BillDb: BaseEntity
{
    /// <summary>
    /// Id of bill
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Public Id of Bill
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// Status of bill
    /// </summary>
    public BillStatus Status { get; set; }

    public bool IsDeleted { get; set; }
    
    /// <summary>
    /// User
    /// </summary>
    public UserDb User { get; set; }
}