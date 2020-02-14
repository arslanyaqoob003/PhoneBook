using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Application.PersonAndCompany
{
    public interface ICompanyPersonAggrigateService
    {
        Task<PersonAndCompanyDto> GetByName(string name);
    }
}