using PhoneBook.Core.Domain;
using System.Collections.Generic;

namespace PhoneBook
{
    // Framework independent Persons repository interface
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> Get(string name);
    }
}
