﻿using FluentAssertions;
using PhoneBook.Application.PersonAndCompany;
using Microsoft.Extensions.DependencyInjection;
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

            var companies = companiesAndPersons.Companies;
            companies.Count.Should().NotBe(0);
            companies.ForEach(x => x.Name.Should().Contain(searchTerm));

            var persons = companiesAndPersons.Persons;
            companiesAndPersons.Persons.Count.Should().NotBe(0);
            persons.ForEach(x => x.Name.Should().Contain(searchTerm));
        }

    }
}
