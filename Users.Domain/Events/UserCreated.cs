using MediatR;
using Users.Domain.ValueObjects;

namespace Users.Domain.Events;

public class UserCreated: INotification
{
    /// <summary>
    /// Id of created user
    /// </summary>
    public UserId Id { get; set; }
    
    /// <summary>
    /// first name of created yser
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of created user
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public string PhoneNumber { get; set; }
}