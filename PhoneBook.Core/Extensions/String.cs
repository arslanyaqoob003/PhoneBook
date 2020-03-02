namespace PhoneBook.Core.Extensions
{
    // string manipulation and extension emthods
    public static class String
    {
        public static bool IsNotNull(this string value) => !string.IsNullOrEmpty(value);
    }
}
