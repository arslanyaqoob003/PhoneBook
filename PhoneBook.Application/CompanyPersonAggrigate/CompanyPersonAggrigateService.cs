using AutoMapper;
using PhoneBook.Application.Companies;
using PhoneBook.Application.Persons;
using System.Threading.Tasks;

namespace PhoneBook.Application.PersonAndCompany
{
    public class CompanyPersonAggrigateService : Service, ICompanyPersonAggrigateService
    {
        // used for mapping values of two objects
        private readonly IMapper _mapper;

        // services
        private readonly ICompanyService _companyService;
        private readonly IPersonService _personService;
        public CompanyPersonAggrigateService(IMapper mapper, ICompanyService companyService,IPersonService personService)
        {
            _mapper = mapper;
            _companyService = companyService;
            _personService = personService;
        }

        public async Task<PersonAndCompanyDto> GetByName(string name)
        {
            return new PersonAndCompanyDto
            {
                Companies = await _companyService.GetByName(name),
                Persons = await _personService.GetByName(name)
            };
        }

    }
}
