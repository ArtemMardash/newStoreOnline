namespace SharedKernal;

public interface IUserCreated
{
    /// <summary>
    /// id of created user
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Public id of user
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// first name of created user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of created user
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// phone number
    /// </summary>
    public string PhoneNumber { get; set; }
    
}