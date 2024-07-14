using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Persistence;

public class UserRepository: IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method to add a new user
    /// </summary>
    public Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        var userDb = user.ToDbEntity();

        return _context.Users.AddAsync(userDb, cancellationToken).AsTask();
    }

    /// <summary>
    /// Method to edit a user
    /// </summary>
    public void EditUser(User user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user.ToDbEntity());
    }

    /// <summary>
    /// Method to get user by id
    /// </summary>
    public async Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        var user = userDb?.ToDomainEntity();

        return user;
    }
}