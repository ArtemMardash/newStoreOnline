using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Persistence;

public class UserRepository: IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }
    
    /// <summary>
    /// Method to add a new user
    /// </summary>
    public Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var userDb = user.ToDbEntity();
        
        user.DomainEvents.Clear();
        return _userContext.Users.AddAsync(userDb, cancellationToken).AsTask();
    }

    /// <summary>
    /// Method to edit a user
    /// </summary>
    public void EditUser(User user, CancellationToken cancellationToken)
    {
        _userContext.Users.Update(user.ToDbEntity());
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