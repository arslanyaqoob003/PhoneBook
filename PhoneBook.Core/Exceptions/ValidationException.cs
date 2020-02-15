namespace PhoneBook.Core.Exceptions
{
    public class ValidationException : PhoneBookException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
