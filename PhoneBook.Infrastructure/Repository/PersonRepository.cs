using PhoneBook.Core.Domain;
using PhoneBook.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Infrastructure.Repository
{
    // Framework dependent Persons repository pattern implementation
    public class PersonRepository : Repository<Person>,IPersonRepository
    {
        public PersonRepository(PhoneBookContext context) : base(context){}
        public IEnumerable<Person> Get(string name = null, string cityName = null, DateTime? dobStart = null, DateTime? dobEnd = null)
        {
            Expression<Func<Person, bool>> whereStatement = null;
            if (name.IsNotNull())
                whereStatement = x => x.Name.ToLower().Contains(name.ToLower());

            if (cityName.IsNotNull())
                whereStatement = whereStatement.And(x => x.City.ToLower().Contains(cityName.ToLower()));

            if (dobStart.IsNotNull())
                whereStatement = whereStatement.And(x => x.DateOfBirth >= dobStart);

            if (dobEnd.IsNotNull())
                whereStatement = whereStatement.And(x => x.DateOfBirth <= dobEnd);

            return context.Persons
                 .NullSafeWhere(whereStatement)
                 .AsEnumerable();
        }
    }
}
