using PhoneBook.Core.Domain;
using System.Collections.Generic;

namespace PhoneBook
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> Get(string name);
    }
}
