using MediatR;
using Users.Domain.ValueObjects;

namespace Users.Domain.Events;

public class UserEdited : INotification
{
    /// <summary>
    /// id of user to edit
    /// </summary>
    public UserId Id { get; set; }

    /// <summary>
    /// new First name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// new Last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// new Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// new Phone number
    /// </summary>
    public string PhoneNumber { get; set; }
}