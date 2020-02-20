using System.Collections.Generic;
using System.Threading.Tasks;
namespace PhoneBook.Application.Persons
{ 
    // service interfae for returning persons
    // contains all the required functions according to requirement document
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAll();
        Task<PersonDto> GetById(int id);
        Task<List<PersonDto>> GetByName(string name);
        Task<PersonDto> Create(PersonDto company);
        Task<PersonDto> Update(PersonDto company);
        Task Delete(int id);
    }
}