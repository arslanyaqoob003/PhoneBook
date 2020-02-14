using FluentAssertions;
using PhoneBook.Application.PersonAndCompany;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace PhoneBook.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class CompanyPersonAggrigateTest : TestBase
    {
        private readonly ICompanyPersonAggrigateService _companyPersonAggrigateService;
        public CompanyPersonAggrigateTest(Fixture fixture) : base(fixture)
        {
            _companyPersonAggrigateService = Services.GetService<ICompanyPersonAggrigateService>();
        }
        [Fact, Priority(0)]
        public async void Should_return_companies_and_persons_by_Name()
        {
            var searchTerm = "A";
            var companiesAndPersons = await _companyPersonAggrigateService.GetByName(searchTerm);
            companiesAndPersons.Should().NotBeNull();
            companiesAndPersons.Companies.Count.Should().NotBe(0);
            companiesAndPersons.Persons.Count.Should().NotBe(0);
        }

    }
}
