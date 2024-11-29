using MediatR;
using Users.Application.Dtos;
using Users.Application.Dtos.Responses;
using Users.Application.Interfaces;

namespace Users.Application.UseCases;

/// <summary>
/// User case to get user by id
/// </summary>
public class GetUserUseCase : IRequestHandler<GetUserDto, UserDto?>
{
    private readonly IUserRepository _repository;

    /// <summary>
    /// Constructor to get user
    /// </summary>
    /// <param name="repository"></param>
    public GetUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Method to get user by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UserDto?> Handle(GetUserDto request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserAsync(request.Id, cancellationToken);
        return user == null
            ? null
            : new UserDto
            {
                Email = user.Email,
                FirstName = user.FullName.FirstName,
                LastName = user.FullName.LastName,
                PhoneNumber = user.PhoneNumber
            };
    }
}