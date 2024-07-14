using Users.Domain.Entities;
using Users.Domain.ValueObjects;

namespace Users.Persistence;

public static class DbExtensions
{
    /// <summary>
    /// Method to convert db user to domain user
    /// </summary>
    /// <param name="userDb"></param>
    /// <returns></returns>
    public static User ToDomainEntity(this UserDb userDb)
    {
        return new User(userDb.Id, userDb.Email, userDb.PhoneNumber, new FullName(userDb.FirstName, userDb.LastName));
    }

    /// <summary>
    /// Method to convert user to db user
    /// </summary>
    public static UserDb ToDbEntity(this User user)
    {
        return new UserDb
        {
            Id = user.Id,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            FirstName = user.FullName.FirstName,
            LastName = user.FullName.LastName
        };
    }
}