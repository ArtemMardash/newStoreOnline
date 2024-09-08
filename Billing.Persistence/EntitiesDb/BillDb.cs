namespace Billing.Persistence.EntitiesDb;

public class BillDb: BaseEntity
{
    /// <summary>
    /// Id of bill
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// User
    /// </summary>
    public UserDb User { get; set; }
}