using Catalog.Domain.ValueObjects;
using SharedKernal;

namespace Catalog.Domain.Entities;

public class Product
{
    private readonly int NAME_LENGTH = 30;
    private readonly int CATEGORY_MAX_LENGTH = 30; 

    /// <summary>
    /// ID of product
    /// </summary>
    public ProductId Id { get; private set; }

    /// <summary>
    /// Name of product
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; private set; }

    /// <summary>
    /// Remaining of product
    /// </summary>
    public int Remaining { get; private set; }

    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; private set; }

    /// <summary>
    /// Unit of measure of product
    /// </summary>
    public Unit Unit { get; set; }

    public Product(string name, double price, int remaining, string category, Unit unit)
    {
        var publicPart =
            new string(DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString().Reverse().ToArray())
                .Substring(0, 4);
        Id = new ProductId(
            Guid.NewGuid(), PublicIdGenerator.Generate("cat", int.Parse(publicPart)));
        SetName(name);
        SetPrice(price);
        SetRemaining(remaining);
        SetCategory(category);
        Unit = unit;
    }

    public Product(ProductId id, string name, double price, int remaining, string category, Unit unit)
    {
        Id = id;
        SetName(name);
        SetPrice(price);
        SetRemaining(remaining);
        SetCategory(category);
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

    public void SetRemaining(int input)
    {
        if (input <= 0)
        {
            throw new ArgumentNullException(nameof(Remaining), "Remaining can not be 0 or less");
        }

        Remaining = input;
    }

    public void SetCategory(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length > CATEGORY_MAX_LENGTH)
        {
            throw new ArgumentOutOfRangeException(nameof(Category), "Category can no be empty or this long");
        }

        Category = input;
    }
}