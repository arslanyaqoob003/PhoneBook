using PhoneBook.Application.Companies;
using PhoneBook.Application.Persons;
using System.Collections.Generic;

namespace PhoneBook.Application.PersonAndCompany
{
    public class PersonAndCompanyDto
    {
        public List<PersonDto> Persons { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
