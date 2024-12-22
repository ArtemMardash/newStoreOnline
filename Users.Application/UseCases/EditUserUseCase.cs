using MediatR;
using Users.Application.Dtos;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Users.Domain.ValueObjects;

namespace Users.Application.UseCases;

/// <summary>
/// Use case to edit data
/// </summary>
public class EditUserUseCase : IRequestHandler<EditUserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _repository;

    /// <summary>
    /// Constructor to edit and save data
    /// </summary>
    public EditUserUseCase(IUnitOfWork unitOfWork, IUserRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    /// <summary>
    /// Method to edit data of user and then save them
    /// </summary>
    public async Task Handle(EditUserDto request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserAsync(request.Id, cancellationToken);
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User with this id doesn't exist");
        }

        var fullName = $"{request.FirstName} {request.LastName}";
        user.Edit(fullName, request.Email, request.PhoneNumber);
        _repository.EditUserAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}