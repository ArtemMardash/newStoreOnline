namespace Shipments.Application.Order.Dtos;

public class OrderUpdatedDto
{
    /// <summary>
    /// Order Id 
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// New Status
    /// </summary>
    public int NewStatus { get; set; }
    
    /// <summary>
    /// Dleivery type
    /// </summary>
    public int DeliveryType { get; set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<ProductDto> Products { get; set; }
    
    /// <summary>
    /// System User id
    /// </summary>
    public Guid SystemUserId { get; set; }

    /// <summary>
    /// Public user Id
    /// </summary>
    public string PublicUserId { get; set; }
}

public class ProductDto
{
    /// <summary>
    /// Public Id of product
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Quantity of products
    /// </summary>
    public int Quantity { get; set; }
}