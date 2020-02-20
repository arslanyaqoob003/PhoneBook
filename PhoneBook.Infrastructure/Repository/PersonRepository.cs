using PhoneBook.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Infrastructure.Repository
{
    // Framework dependent Persons repository pattern implementation
    public class PersonRepository : Repository<Person>,IPersonRepository
    {
        public PersonRepository(PhoneBookContext context) : base(context){}
        public IEnumerable<Person> Get(string name)
        {
            return context.Persons
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsEnumerable();
        }
    }
}
