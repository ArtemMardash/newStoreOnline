using System.Runtime.InteropServices;
using FluentAssertions;
using Users.Domain.Extensions;

namespace Users.Tests.DomainTests;

public class ExtensionsTests
{
    [Theory]
    [InlineData("artem.m@gmail.com")]
    [InlineData("1@m.c")]
    public void Is_Valid_Email_Should_Succesesfull(string email)
    {
        var result = email.IsValidEmail();

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("a.a")]
    [InlineData("1@m.ca1@.m")]
    [InlineData("a1@.m")]
    public void Is_Valid_Email_Should_Fail(string email)
    {
        var result = email.IsValidEmail();

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("(123)1231234")]
    [InlineData("222-333-4444")]
    [InlineData("(222)-333-4444")]
    [InlineData("12345678901234")]
    public void Is_Valid_Phone_NUmber_Should_SuccesesFull(string phoneNumber)
    {
        var result = phoneNumber.IsValidPhoneNumber();

        result.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("123")]
    [InlineData("(123)-(333)-(1212)")]
    [InlineData("(123)(123)4123")]
    [InlineData("123456789012345")]
    public void Is_Valid_Phone_NUmber_Should_Fail(string phoneNumber)
    {
        var result = phoneNumber.IsValidPhoneNumber();

        result.Should().BeFalse();
    }
}