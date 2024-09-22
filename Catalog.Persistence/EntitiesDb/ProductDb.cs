namespace Catalog.Persistence.EntitiesDb;

public class ProductDb
{
    public Guid SystemId { get; set; }
    
    public string PublicId { get; set; }
    
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Remaning { get; set; }
    
    public string Category { get; set; }
    
    public int Unit { get; set; }
}