using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Persistence;

public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    /// <summary>
    /// Method to add a new user
    /// </summary>
    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var isExisted =
            await _userContext.Users.AnyAsync(
                u => u.PhoneNumber == user.PhoneNumber || u.Email == user.Email, cancellationToken);
        if (!isExisted)
        {
            var userDb = user.ToDbEntity();

            user.DomainEvents.Clear();
            await _userContext.Users.AddAsync(userDb, cancellationToken).AsTask();
        }
        else
        {
            throw new InvalidOperationException(
                $"The user with email {user.Email} or phone number {user.PhoneNumber} already exists");
        }
    }

    /// <summary>
    /// Method to edit a user
    /// </summary>
    public async Task EditUserAsync(User user, CancellationToken cancellationToken)
    {
        var userDb = await _userContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id.SystemId, cancellationToken);
        if (userDb == null)
        {
            throw new InvalidOperationException("User not found");
        }

        userDb.PhoneNumber = user.PhoneNumber;
        userDb.FirstName = user.FullName.FirstName;
        userDb.Email = user.Email;
        userDb.LastName = user.FullName.LastName;
        userDb.DomainEvents = user.DomainEvents;
        
        user.DomainEvents.Clear();
    }

    /// <summary>
    /// Method to get user by id
    /// </summary>
    public async Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var userDb = await _userContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        var user = userDb?.ToDomainEntity();

        return user;
    }
}