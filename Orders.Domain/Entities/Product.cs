namespace Orders.Domain.Entities;

public class Product
{
    /// <summary>
    /// System Id of product
    /// </summary>
    public Guid SystemId { get; private set; }
    
    /// <summary>
    /// Public Id pf product
    /// </summary>
    public string PublicId { get; private set; }
    
    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; private set; }
    
    /// <summary>
    /// Quantity of product
    /// </summary>
    public int Quantity { get; private set; }
    
    public Product( Guid systemId,string publicId, double price, int quantity)
    {
        SystemId = systemId;
        PublicId = publicId;
        Price = price;
        Quantity = quantity;

    }
    
}