namespace Catalog.Persistence.EntitiesDb;

public class ProductDb
{
    
    /// <summary>
    /// System Id of product
    /// </summary>
    public Guid SystemId { get; set; }
    /// <summary>
    /// Public Id of product
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Name of product
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Remaining of product
    /// </summary>
    public int Remaning { get; set; }
    
    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Type of unit of product
    /// </summary>
    public int Unit { get; set; }
}