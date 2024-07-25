namespace Users.Persistence;

public class UserDb: EntityDb
{
    /// <summary>
    /// id of user
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Public id of user
    /// </summary>
    public string PublicId { get; set; }
    
    /// <summary>
    /// phone number of user
    /// </summary>
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// Email of user
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// first Name of user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of user
    /// </summary>
    public string LastName { get; set; }
}