using PhoneBook.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> Get(string name);
    }
}
