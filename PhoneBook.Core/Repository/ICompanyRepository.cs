using PhoneBook.Core.Domain;
using System.Collections.Generic;

namespace PhoneBook
{
    // Framework independent Companies repository interface
    public interface ICompanyRepository:IRepository<Company>
    {
        IEnumerable<Company> Get(string name = null, string cityName = null);
    }
}
