namespace Orders.Persistence.DbEntities;

public class ProductDb: BaseEntity
{
    public string PublicId { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }

    public List<OrderDb> Orders { get; set; } = new List<OrderDb>();
}