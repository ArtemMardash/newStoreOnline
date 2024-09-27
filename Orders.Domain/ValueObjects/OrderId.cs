namespace Orders.Domain.ValueObjects;

public class OrderId
{
    /// <summary>
    /// Id of Order Guid
    /// </summary>
    public Guid SystemId { get; private set; }
    
    /// <summary>
    /// String id of Order
    /// </summary>
    public string PublicId { get; private set; }

    /// <summary>
    /// Order id which contains string and guid type of id
    /// </summary>
    public OrderId(Guid systemId, string publicId)
    {
        if (systemId == Guid.Empty)
        {
            throw new ArgumentException("Invalid Id");
        }
        SystemId = systemId;
        SetPublicId(publicId);
    }
    
    /// <summary>
    /// Method to set public id
    /// </summary>
    public void SetPublicId(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Invalid public Id");
        }

        PublicId = input;
    }
}