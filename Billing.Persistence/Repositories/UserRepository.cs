using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Persistence.EntitiesDb;

namespace Billing.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly BillingContext _context;

    public UserRepository(BillingContext context)
    {
        _context = context;
    }
    
    public Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        var userDb = new UserDb
        {
            Id = user.Id.SystemId,
            PublicId = user.Id.PublicId,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            LastName = user.LastName,
            FirstName = user.FirstName
        };
        return _context.Users.AddAsync(userDb, cancellationToken).AsTask();
    }
}