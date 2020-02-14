using PhoneBook.Application.Companies;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit.Priority;

namespace PhoneBook.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class CompanyTest: TestBase
    {
        private ICompanyService _companyService;
        public CompanyTest(Fixture fixture) : base(fixture) 
        {
            _companyService = Services.GetService<ICompanyService>();
        }

        [Fact, Priority(0)]
        public async void All_Companies()
        {
            var companies = await _companyService.GetAll();
            companies.Should().NotBeNull();
            companies.Count.Should().Be(2);
        }

        [Theory, Priority(1)]
        [InlineData(1)]
        public async void Company_by_Id(int companyId)
        {
            var company = await _companyService.GetById(companyId);
            company.Should().NotBeNull();
            company.Site.Should().Be("www.allianstrafikskola.se");
        }
        [Fact, Priority(2)]
        public void Create_Company_should_return_Validation_Error()
        {
            Func<Task> action = () => _companyService.Create(new CompanyDto());
            action.Should().Throw<ValidationException>();
        }
        [Fact, Priority(3)]
        public async void Create_Company()
        {
            var dto = new CompanyDto
            {
                Name = "Test Company",
                Site = "www.test.se",
                Address = "Danmarksgatan 4616440 KISTA",
                DateOfCreation = new DateTime(2007, 3, 1),
                Rating = 5,
                TelephoneNumber = "0761645436",
                Latitude = 29.56512,
                Longitude = 167.56756,
                Summary = "This is test summary",

            };
            var company = await _companyService.Create(dto);
            company.Should().NotBeNull();
            company.Id.Should().NotBe(0);
            company.Name.Should().Be("Test Company");
            company.Site.Should().Be("www.test.se");

            company =  await _companyService.GetById(company.Id);

            company.Should().NotBeNull();
            company.Id.Should().NotBe(0);
            company.Name.Should().Be("Test Company");
            company.Site.Should().Be("www.test.se");
        }
        [Theory, Priority(4)]
        [InlineData(1)]
        public async void Delete_Company(int companyId)
        {
            await _companyService.Delete(companyId);
            var company = await _companyService.GetById(companyId);
            company.Should().BeNull();
        }
    }
}
