using Users.Domain.Entities;

namespace Users.Application.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Method to add a new user
    /// </summary>
    public Task AddUserAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Method to edit a user
    /// </summary>
    public Task EditUserAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Method to get user by id
    /// </summary>
    public Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken);
}