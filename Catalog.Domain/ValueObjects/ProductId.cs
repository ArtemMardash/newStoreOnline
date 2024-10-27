namespace Catalog.Domain.ValueObjects;

public class ProductId
{
    /// <summary>
    /// System id of product
    /// </summary>
    public Guid SystemId { get; set; }

    /// <summary>
    /// Public Id of product
    /// </summary>
    public string PublicId { get; set; }

    public ProductId(Guid systemId, string publicId)
    {
        if (systemId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id");
        }

        SystemId = systemId;
        SetPublicId(publicId);
    }

    /// <summary>
    /// Method to set a public Id
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="ArgumentException"></exception>
    private void SetPublicId(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Invalid public Id");
        }

        PublicId = input;
    }
}