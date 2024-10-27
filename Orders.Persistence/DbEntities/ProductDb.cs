namespace Orders.Persistence.DbEntities;

public class ProductDb: EntityDb
{
    /// <summary>
    /// System Id of product
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// Public Id of Product
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Quantity of product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// List of orders that have that product
    /// </summary>
    public List<OrderDb> Orders { get; set; } = new List<OrderDb>();
}