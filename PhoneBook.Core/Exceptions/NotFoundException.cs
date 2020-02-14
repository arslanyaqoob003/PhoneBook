using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Exceptions
{
    public class NotFoundException : PhoneBookException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
