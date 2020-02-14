using PhoneBook.Application.Companies;
using PhoneBook.Application.Persons;
using PhoneBook.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Application.PersonAndCompany
{
    public class PersonAndCompanyDto
    {
        public List<PersonDto> Persons { get; set; }
        public List<CompanyDto> Companies { get; set; }
    }
}
