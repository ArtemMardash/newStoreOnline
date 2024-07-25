namespace Billing.Persistence.EntitiesDb;

public class BillDb: BaseEntity
{
    public int Id { get; set; }
    
    public UserDb User { get; set; }
}