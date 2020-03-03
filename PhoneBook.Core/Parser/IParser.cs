using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Core.Parser
{
    // actual parser interface
    public interface IParser : IDisposable
    {
        List<T> ToObjectList<T>();
    }
}
