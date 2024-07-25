namespace SharedKernal;

public interface IUserEdited
{
    /// <summary>
    /// id of user to edit
    /// </summary>
    public Guid Id { get; set; }
    
    public string PublicId { get; set; }
    
    /// <summary>
    /// new first name
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// new last name
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// new email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// new phone number
    /// </summary>
    public string PhoneNumber { get; set; }
    
}