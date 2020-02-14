using PhoneBook.Core.Domain;

namespace PhoneBook.Infrastructure.Repository
{
    public class PersonRepository : Repository<Person>,IPersonRepository
    {
        public PersonRepository(PhoneBookContext context) : base(context){}
    }
}
