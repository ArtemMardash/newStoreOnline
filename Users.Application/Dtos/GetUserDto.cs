using MediatR;
using Users.Application.Dtos.Responses;

namespace Users.Application.Dtos;

/// <summary>
/// Dto to get user by id
/// </summary>
public class GetUserDto: IRequest<UserDto>
{
    /// <summary>
    /// Id of user
    /// </summary>
    public Guid Id { get; set; }
}