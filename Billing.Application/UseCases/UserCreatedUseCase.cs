using Billing.Application.Interfaces;
using Billing.Domain.Entities;

namespace Billing.Application.UseCases;

public class UserCreatedUseCase: IUserCreatedUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserCreatedUseCase(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    public async Task ExecuteAsync(User user, CancellationToken cancellationToken)
    {
        await _userRepository.SaveAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}