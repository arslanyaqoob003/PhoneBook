using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Extensions
{
    /// <summary>
    /// Extension methods to check objects,
    /// </summary>
    public static class Object
    {
        public static bool IsNotNull(this object value) => !(value==null);
        public static bool IsNull(this object value) => (value==null);
    }
}
