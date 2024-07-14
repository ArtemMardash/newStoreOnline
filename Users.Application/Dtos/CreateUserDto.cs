using MediatR;

namespace Users.Application.Dtos;

/// <summary>
/// Dto to create a new user
/// </summary>
public class CreateUserDto: IRequest
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