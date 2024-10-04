using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities;

public class User
{
    /// <summary>
    /// Id Of User
    /// </summary>
   public UserId Id { get; private set; }
    
    /// <summary>
    /// phone number of user
    /// </summary>
    public string PhoneNumber { get; private set; }
    
    /// <summary>
    /// Email of user
    /// </summary>
    public string Email { get; private set; }
    
    /// <summary>
    /// first Name of user
    /// </summary>
    public string FirstName { get; private set; }
    
    /// <summary>
    /// last name of user
    /// </summary>
    public string LastName { get; private set; }
    
    
    public User(UserId id, string email, string phoneNumber, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
    }
    
}