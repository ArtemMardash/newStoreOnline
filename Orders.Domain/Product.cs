using Orders.Domain.ValueObjects;

namespace Orders.Domain;

public class Product
{
    public string PublicId { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }

    /// <summary>
    /// цена и кол-во должна быть больше 0 и надо тримить паблик Id
    /// </summary>
    /// <param name="publicId"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    public Product(string publicId, double price, int quantity)
    {
        PublicId = publicId;
        Price = price;
        Quantity = quantity;

    }
    
}