using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Billing.Persistence.EntitiesDb;
using Microsoft.EntityFrameworkCore;

namespace Billing.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BillingContext _context;

    public UserRepository(BillingContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to add user to bill db
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task AddAsync(User user, CancellationToken cancellationToken)
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

    /// <summary>
    /// Method to update user's data
    /// </summary>
    public async Task UpdateAsync(User updatedUser, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id.SystemId);
        if (user == null)
        {
            throw new InvalidOperationException("There is no user with such ID");
        }

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.PhoneNumber = updatedUser.PhoneNumber;
        user.Email = updatedUser.Email;
    }

    /// <summary>
    /// Method to get user by id
    /// </summary>
    public async Task<User> GetUserByIdAsync(Guid userSystemId, CancellationToken cancellationToken)
    {
        var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == userSystemId, cancellationToken);

        if (userDb == null)
        {
            throw new InvalidOperationException("There is no user with such ID");
        }
        var user = new User(new UserId(userDb.Id, userDb.PublicId), userDb.Email, userDb.PhoneNumber, userDb.FirstName,
            userDb.LastName);
        return user;
    }
}