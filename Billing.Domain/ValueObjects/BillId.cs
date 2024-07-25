namespace Billing.Domain.ValueObjects;

public class BillId
{
    /// <summary>
    /// Id of Bill Guid
    /// </summary>
    public Guid SystemId { get; private set; }
    
    /// <summary>
    /// String id of Bill
    /// </summary>
    public string PublicId { get; private set; }

    /// <summary>
    /// Bill id which contains string and guid type of id
    /// </summary>
    public BillId(Guid systemId, string publicId)
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