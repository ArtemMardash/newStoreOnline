namespace Orders.Persistence.DbEntities;

public class OrderDb: BaseEntity
{
    public Guid SystemId { get; set; }
    
    public string PublicId { get; set; }
    
    public int DeliveryType { get; set; }
    
    public int Status { get; set; }
    
    public List<ProductDb> Products { get; set; } 
    
}