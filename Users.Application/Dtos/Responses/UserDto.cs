namespace Users.Application.Dtos.Responses;

/// <summary>
/// Data to show user's data
/// </summary>
public class UserDto
{
    /// <summary>
    /// Email of user
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Phone number of user
    /// </summary>
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// First name of user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Last name of user
    /// </summary>
    public string LastName { get; set; }
}