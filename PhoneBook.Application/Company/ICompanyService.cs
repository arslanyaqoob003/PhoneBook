using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAll();
        Task<CompanyDto> GetById();
        Task<CompanyDto> Create();
        Task<CompanyDto> Update();
        Task<CompanyDto> Delete();
    }
}