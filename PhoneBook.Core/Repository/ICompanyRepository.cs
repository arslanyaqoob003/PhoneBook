using PhoneBook.Core.Domain;
using System.Collections.Generic;

namespace PhoneBook
{
    public interface ICompanyRepository:IRepository<Company>
    {
        IEnumerable<Company> Get(string name);
    }
}
