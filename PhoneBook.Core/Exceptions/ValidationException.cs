namespace PhoneBook.Core.Exceptions
{
    // Our Custom implementation of Validation exception
    // It used to Differentiates between Our code error and framework error
    public class ValidationException : PhoneBookException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
