namespace SharedKernal;

public interface IUserCreated
{
    /// <summary>
    /// id of created user
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// first name of created user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of created user
    /// </summary>
    public string LastName { get; set; }
}