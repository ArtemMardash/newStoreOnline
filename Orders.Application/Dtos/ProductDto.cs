namespace Orders.Application.Dtos;

public class ProductDto
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
    /// Price of product
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Quantity of product
    /// </summary>
    public int Quantity { get; set; }
}