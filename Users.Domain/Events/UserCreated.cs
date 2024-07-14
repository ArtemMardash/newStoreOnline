using MediatR;

namespace Users.Domain.Events;

public class UserCreated: INotification
{
    /// <summary>
    /// Id of created user
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// first name of created yser
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of created user
    /// </summary>
    public string LastName { get; set; }
}