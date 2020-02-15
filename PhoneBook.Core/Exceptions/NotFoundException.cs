namespace PhoneBook.Core.Exceptions
{
    public class NotFoundException : PhoneBookException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
