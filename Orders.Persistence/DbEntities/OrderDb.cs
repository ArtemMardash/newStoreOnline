namespace Orders.Persistence.DbEntities;

public class OrderDb: EntityDb
{
    public Guid SystemId { get; set; }
    
    public string PublicId { get; set; }
    
    public int DeliveryType { get; set; }
    
    public int Status { get; set; }
    
    public Guid SystemUserId { get; set; }
    
    public string PublicUserId { get; set; }
    
    public List<ProductDb> Products { get; set; } 
    
}