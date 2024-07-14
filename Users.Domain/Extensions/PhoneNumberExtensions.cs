using System.Text.RegularExpressions;

namespace Users.Domain.Extensions;

/// <summary>
/// Class for extension methods for phoneNumber
/// </summary>
public static class PhoneNumberExtensions
{
    /// <summary>
    /// check if phone number is valid and suit for regular expression
    /// </summary>
    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length > 14)
        {
            return false;
        }
        
        try
        {
            return Regex.IsMatch(phoneNumber, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}