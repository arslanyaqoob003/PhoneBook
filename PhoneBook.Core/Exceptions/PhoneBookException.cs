using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Exceptions
{
    // Seperate class of Exception to know the Context of app
    public class PhoneBookException:Exception
    {
        public PhoneBookException(string message) : base(message) { }
    }
}
