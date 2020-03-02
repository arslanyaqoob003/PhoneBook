using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Extensions
{
    public static class Object
    {
        public static bool IsNotNull(this object value) => !(value==null);
    }
}
