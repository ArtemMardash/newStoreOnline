namespace Orders.Application.Dtos;

public class OrderResponse
{
    /// <summary>
    /// System Id of order
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// Public Id of order
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// Delivery type of order
    /// </summary>
    public int DeliveryType { get; set; }
    
    /// <summary>
    /// Status of Order
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// List of products 
    /// </summary>
    public List<ProductDto> Products { get; set; }
    
    /// <summary>
    /// System Id of user
    /// </summary>
    public Guid SystemUserId { get; set; }
    
    /// <summary>
    /// Public id of user
    /// </summary>
    public string PublicUserId { get; set; }
}