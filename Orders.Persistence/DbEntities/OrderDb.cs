namespace Orders.Persistence.DbEntities;

public class OrderDb: EntityDb
{
    /// <summary>
    /// System Id of order
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// Public Id of Order
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Delivery type of order
    /// </summary>
    public int DeliveryType { get; set; }
    
    /// <summary>
    /// Status of order
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// System Id of user
    /// </summary>
    public Guid SystemUserId { get; set; }
    
    /// <summary>
    /// Public Id of user
    /// </summary>
    public string PublicUserId { get; set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<ProductDb> Products { get; set; } 
    
}