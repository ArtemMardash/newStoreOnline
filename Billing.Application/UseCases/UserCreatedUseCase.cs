using Billing.Application.Interfaces;
using Billing.Domain.Entities;

namespace Billing.Application.UseCases;

public class UserCreatedUseCase: IUserCreatedUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Constructor to create and save user
    /// </summary>
    public UserCreatedUseCase(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    /// <summary>
    /// Method to create and save user
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    public async Task ExecuteAsync(User user, CancellationToken cancellationToken)
    {
        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}