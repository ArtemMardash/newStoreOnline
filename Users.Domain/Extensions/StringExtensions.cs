namespace Users.Domain.Extensions;

public static class StringExtensions
{
    public static string Capitalize(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("invalid input");
        }
        input = input.ToLower();
        input = $"{char.ToUpper(input[0])}{input.Substring(1)}";
        return input;
    }
}