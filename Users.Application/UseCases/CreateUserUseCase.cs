using MediatR;
using Users.Application.Dtos;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Users.Domain.ValueObjects;

namespace Users.Application.UseCases;

/// <summary>
/// Use case to create user
/// </summary>
public class CreateUserUseCase: IRequestHandler<CreateUserDto, Guid>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor to save and create user
    /// </summary>
    public CreateUserUseCase(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Method to create and add a new user
    /// </summary>
    public async Task<Guid> Handle(CreateUserDto request, CancellationToken cancellationToken)
    {
        var user = new User(request.Email, request.PhoneNumber,
            new FullName(request.FirstName, request.LastName));
        await  _repository.AddUserAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user.Id.SystemId;
    }
}