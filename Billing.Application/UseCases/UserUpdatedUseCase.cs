using Billing.Application.Interfaces;
using Billing.Domain.Entities;

namespace Billing.Application.UseCases;

public class UserUpdatedUseCase: IUserUpdatedUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _repository;

    /// <summary>
    /// Constructor to save and update user
    /// </summary>
    public UserUpdatedUseCase(IUnitOfWork unitOfWork, IUserRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    /// <summary>
    /// Method to save and update user
    /// </summary>
    public async Task ExecuteAsync(User updatedUser, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(updatedUser, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}