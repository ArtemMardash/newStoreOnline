namespace Catalog.Domain.ValueObjects;

public class ProductId
{
    public Guid SystemId { get; set; }

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

    private void SetPublicId(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Invalid public Id");
        }

        PublicId = input;
    }
}