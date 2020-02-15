using System;

namespace PhoneBook.Core.Exceptions
{
    // Seperate class of Exception to know the Context of app
    public class PhoneBookException:Exception
    {
        public PhoneBookException(string message) : base(message) { }
    }
}
