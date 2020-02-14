using System.Collections.Generic;
using System.Threading.Tasks;
namespace PhoneBook.Application.Persons
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAll();
        Task<PersonDto> GetById(int id);
        Task<PersonDto> Create(PersonDto company);
        Task<PersonDto> Update(PersonDto company);
        Task Delete(int id);
    }
}