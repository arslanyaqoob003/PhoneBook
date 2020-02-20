using PhoneBook.Application.Companies;
using PhoneBook.Application.Persons;
using System.Collections.Generic;

namespace PhoneBook.Application.PersonAndCompany
{
    // DTO means Data Transfer Object
    // DTO and domain Models must be seperate in order to increase decouping and flexibility
    // This is Company and Person into same DTO which can be used to exchange data to\from services (Application Layer)
    public class PersonAndCompanyDto
    {
        public List<PersonDto> Persons { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
