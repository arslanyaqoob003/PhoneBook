using System.Threading.Tasks;

namespace PhoneBook.Application.PersonAndCompany
{
    // service interface for returning comapnies and persons in aggrigate object
    public interface ICompanyPersonAggrigateService
    {
        Task<PersonAndCompanyDto> GetByName(string name);
    }
}