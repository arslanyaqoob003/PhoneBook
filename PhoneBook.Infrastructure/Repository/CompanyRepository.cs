using PhoneBook.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company>,ICompanyRepository 
    {
        public CompanyRepository(PhoneBookContext context) : base(context){}

        public IEnumerable<Company> Get(string name)
        {
            return context.Companies
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsEnumerable();
        }
    }
}
