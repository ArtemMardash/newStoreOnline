namespace SharedKernal;

public static class PublicIdGenerator
{
    public static string Generate(string prefix, int counter)
    {
        if (prefix.Length != 3)
        {
            throw new ArgumentException("Invalid prefix");
        }

        var rand = new Random();
        return $"{prefix}-{rand.Next(100000, 999999)}-{counter + 1}";
    }
}