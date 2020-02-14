using PhoneBook.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface ICompanyRepository:IRepository<Company>
    {
        IEnumerable<Company> Get(string name);
    }
}
