namespace Orders.Application.Dtos;

public class ProductDto
{
    public string PublicId { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
}