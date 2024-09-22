using Catalog.Domain.ValueObjects;
using SharedKernal;

namespace Catalog.Domain.Entities;

public class Product
{
    private readonly int NAME_LENGTH = 30;
    
    /// <summary>
    /// ID of product
    /// </summary>
    public ProductId Id { get; set; }
    
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
    public int Remaining { get; set; }
    
    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Unit of measure of product
    /// </summary>
    public Unit Unit { get; set; }

    public Product(string name, double price, int remaining, string category, Unit unit)
    {
        var publicPart =
            new string(DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString().Reverse().ToArray()).Substring(0,4);
        Id = new ProductId(
            Guid.NewGuid(), PublicIdGenerator.Generate("cat", int.Parse(publicPart)));
        SetName(name);
        SetPrice(price);
        Remaining = remaining;
        Category = category;
        Unit = unit;
    }
    
    public Product(ProductId id,string name, double price, int remaining, string category, Unit unit)
    {
        Id = id;
        SetName(name);
        SetPrice(price);
        Remaining = remaining;
        Category = category;
        Unit = unit;
    }

    public void SetName(string input)
    {
        if (string.IsNullOrEmpty(input) && input.Length < NAME_LENGTH)
        {
            throw new ArgumentException("Invalid name Id");
        }

        Name = input;
    }

    public void SetPrice(double price)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price can not be zero or less");
        }

        Price = price;
    }
    
}