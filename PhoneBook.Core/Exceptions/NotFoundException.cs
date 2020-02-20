namespace PhoneBook.Core.Exceptions
{
    // Our Custom implementation of Not found exception
    // It used to Differentiates between Our code error and framework error
    public class NotFoundException : PhoneBookException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
