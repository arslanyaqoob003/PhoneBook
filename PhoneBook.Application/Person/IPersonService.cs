using System.Collections.Generic;
using System.Threading.Tasks;
namespace PhoneBook.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAll();
        Task<PersonDto> GetById();
        Task<PersonDto> Create();
        Task<PersonDto> Update();
        Task<PersonDto> Delete();
    }
}