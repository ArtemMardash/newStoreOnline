namespace Orders.Domain.ValueObjects;

public class UserId
{
    /// <summary>
    /// Id of User Guid
    /// </summary>
    public Guid SystemId { get; private set; }
    
    /// <summary>
    /// String id of User
    /// </summary>
    public string PublicId { get; private set; }

    /// <summary>
    /// User id which contains string and guid type of id
    /// </summary>
    public UserId(Guid systemId, string publicId)
    {
        if (systemId == Guid.Empty)
        {
            throw new ArgumentException("Invalid system id");
        }
        SystemId = systemId;
        SetPublicId(publicId);
    }
    
    /// <summary>
    /// Set public id of user
    /// </summary>
    public void SetPublicId(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Invalid public id");
        }

        PublicId = input;
    }
}