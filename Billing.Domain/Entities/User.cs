using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities;

public class User
{
    /// <summary>
    /// Id Of User
    /// </summary>
   public UserId Id { get; set; }
    
    /// <summary>
    /// phone number of user
    /// </summary>
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// Email of user
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// first Name of user
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// last name of user
    /// </summary>
    public string LastName { get; set; }
    
    
    public User(UserId id, string email, string phoneNumber, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
    }
}