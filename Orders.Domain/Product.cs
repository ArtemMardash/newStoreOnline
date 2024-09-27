using Orders.Domain.ValueObjects;

namespace Orders.Domain;

public class Product
{
    public string PublicId { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
    
}