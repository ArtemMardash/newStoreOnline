using FluentAssertions;
using Users.Domain.Entities;
using Users.Domain.ValueObjects;

namespace Users.Tests.DomainTests;

public class UserTests
{
    [Theory]
    [InlineData("Artem", "Mardakhaev", "12345678901", "artem@gmail.com")]
    public void Create_User_Should_Successfull(string firstName, string lastName, string phoneNumber, string email)
    {
        var test = () =>
        {
            var user = new User(email, phoneNumber, new FullName(firstName, lastName));
            return user;
        };
        test.Should().NotBeNull();
        test.Should().NotThrow();
        var user = test();
        user.FullName.Should().NotBeNull();
        user.Email.Should().NotBeNull();
        user.PhoneNumber.Should().NotBeNull();

    }
    
    [Theory]
    [InlineData("Artem", "", "12345678901", "artem@gmail.com")]
    [InlineData("", "Mardakhaev", "12345678901", "artem@gmail.com")]
    [InlineData("ARten", "Mardakhaev", "", "artem@gmail.com")]
    [InlineData("Artem", "Mardakhaev", "12345678901", "")]
    [InlineData(null, "Mardakhaev", "12345678901", "artem@gmail.com")]
    [InlineData("Artem", null, "12345678901", "artem@gmail.com")]
    [InlineData("Artem", "Mardakhaev", null, "artem@gmail.com")]
    [InlineData("Artem", "Mardakhaev", "12345678901", null)]
    public void Create_User_Should_Fail(string firstName, string lastName, string phoneNumber, string email)
    {
        var test = () =>
        {
            var user = new User(email, phoneNumber, new FullName(firstName, lastName));
            return user;
        };
        test.Should().Throw<Exception>();

    }
    
}