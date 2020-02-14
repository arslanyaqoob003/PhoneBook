using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Application.Companies
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAll();
        Task<CompanyDto> GetById(int id);
        Task<List<CompanyDto>> GetByName(string name);
        Task<CompanyDto> Create(CompanyDto company);
        Task<CompanyDto> Update(CompanyDto company);
        Task Delete(int id);
    }
}