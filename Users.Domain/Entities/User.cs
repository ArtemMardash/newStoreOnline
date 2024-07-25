using System.Runtime.InteropServices.JavaScript;
using SharedKernal;
using Users.Domain.Events;
using Users.Domain.Extensions;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities;

public class User : BaseEntity
{
    /// <summary>
    /// Id of user
    /// </summary>
   public UserId Id { get; set; }

    /// <summary>
    /// Phone number of user
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email of user
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Full name of user
    /// </summary>
    public FullName FullName { get; set; }

    /// <summary>
    /// Constructor with id
    /// </summary>
    public User(UserId id, string email, string phoneNumber, FullName fullName)
    {
        Id = id;
        SetEmail(email);
        SetPhoneNumber(phoneNumber);
        SetFullName(fullName.ToString());
    }

    /// <summary>
    /// Constructor without id
    /// </summary>
    public User(string email, string phoneNumber, FullName fullName)
    {
        Id = new UserId(Guid.NewGuid(),
            PublicIdGenerator.Generate("usr", int.Parse(DateTime.UtcNow.Millisecond.ToString().Substring(0, 4))));
        SetEmail(email);
        SetPhoneNumber(phoneNumber);
        SetFullName(fullName.ToString());
        DomainEvents.Add(new UserCreated
        {
            Id = Id, 
            FirstName = FullName.FirstName,
            LastName = FullName.LastName,
            PhoneNumber = PhoneNumber,
            Email = Email
        });
    }


    /// <summary>
    /// Method to check phone number if it's valid
    /// </summary>
    private void SetPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.IsValidPhoneNumber())
        {
            PhoneNumber = phoneNumber;
        }
        else
        {
            throw new ArgumentException("Phone number is in wrong format", nameof(PhoneNumber));
        }
    }

    /// <summary>
    /// Method to check email if it's valid
    /// </summary>
    /// <param name="email"></param>
    /// <exception cref="ArgumentException"></exception>
    private void SetEmail(string email)
    {
        if (email.IsValidEmail())
        {
            Email = email;
        }
        else
        {
            throw new ArgumentException("Email is in wrong format", nameof(PhoneNumber));
        }
    }

    /// <summary>
    /// Method to check full name if it's valid
    /// </summary>
    private void SetFullName(string input)
    {
        var splitedString = input.Split(' ');
        if (splitedString.Length != 2)
        {
            throw new ArgumentException(nameof(input), "Invalid convert from string to Full Name");
        }

        var firstName = splitedString[0];
        var lastName = splitedString[1];

        var result = new FullName(firstName.Capitalize(), lastName.Capitalize());

        FullName = result;
    }

    public void Edit(string? fullName, string? email, string? phoneNumber)
    {
        var hasChanges = false;
        SetIfNotNull(fullName, s =>
        {
            SetFullName(s);
            hasChanges = true;
        });

        SetIfNotNull(email, s =>
        {
            SetEmail(s);
            hasChanges = true;
        });

        SetIfNotNull(phoneNumber, s =>
        {
            SetPhoneNumber(s);
            hasChanges = true;
        });

        if (hasChanges)
        {
            DomainEvents.Add(new UserEdited
            {
                Id = Id,
                Email = Email,
                FirstName = FullName.FirstName,
                LastName = FullName.LastName,
                PhoneNumber = PhoneNumber
            });
        }

        void SetIfNotNull(string? input, Action<string> action)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                action(input);
            }
        }
    }
}