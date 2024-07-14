using MediatR;

namespace Users.Application.Dtos;

/// <summary>
/// Dto to edit user's data
/// </summary>
public class EditUserDto: IRequest
{
    /// <summary>
    /// Id of user to edit
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// new email of user
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// new phone number of user
    /// </summary>
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// new first name of user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// new last name of user
    /// </summary>
    public string LastName { get; set; }
}