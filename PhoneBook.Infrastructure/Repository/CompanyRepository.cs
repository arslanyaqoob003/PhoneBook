using PhoneBook.Core.Domain;
using PhoneBook.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace PhoneBook.Infrastructure.Repository
{
    // Framework dependent Companies repository pattern implementation
    public class CompanyRepository : Repository<Company>,ICompanyRepository 
    {
        public CompanyRepository(PhoneBookContext context) : base(context){}
        public IEnumerable<Company> Get(string name = null, string cityName = null)
        {
            Expression<Func<Company, bool>> whereStatement = null;
            var query = context.Companies.AsQueryable();
            if (name.IsNotNull())
                whereStatement = x => x.Name.ToLower().Contains(name.ToLower());

            if (cityName.IsNotNull())
               whereStatement= whereStatement.And(x => x.City.ToLower().Contains(cityName.ToLower()));

            return context.Companies
                 .NullSafeWhere(whereStatement)
                 .AsEnumerable();
        }
    }
}
