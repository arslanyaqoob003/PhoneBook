using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit.Priority;
using PhoneBook.Application.Persons;

namespace PhoneBook.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class PersonTest : TestBase
    {
        private IPersonService _personService;
        public PersonTest(Fixture fixture) : base(fixture)
        {
            _personService = Services.GetService<IPersonService>();
        }

        [Fact, Priority(0)]
        public async void All_Persons()
        {
            var persons = await _personService.GetAll();
            persons.Should().NotBeNull();
            persons.Count.Should().Be(2);
        }

        [Theory, Priority(1)]
        [InlineData(1)]
        public async void Person_by_Id(int personId)
        {
            var person = await _personService.GetById(personId);
            person.Should().NotBeNull();
            person.Id.Should().Be(1);
        }
        [Fact, Priority(2)]
        public void Create_Person_should_return_Validation_Error()
        {
            Func<Task> action = () => _personService.Create(new PersonDto());
            action.Should().Throw<ValidationException>();
        }
        [Fact, Priority(3)]
        public async void Create_Person()
        {
            var name = "Test Person";
            var dto = new PersonDto
            {
                Name = name,
                Address = "Denmark 4616440 KISTA",
                DateOfBirth = new DateTime(1994, 3, 1),
                TelephoneNumber = "0761645436",
                Latitude = 29.56512,
                Longitude = 167.56756,

            };
            var person = await _personService.Create(dto);
            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
            person.Name.Should().Be(name);

            person = await _personService.GetById(person.Id);

            person.Should().NotBeNull();
            person.Id.Should().NotBe(0);
            person.Name.Should().Be(name);
        }
        [Theory, Priority(4)]
        [InlineData(1)]
        public async void Update_Person(int personId)
        {
            var name = "Test John";
            personId.Should().NotBe(0);

            var dto = await _personService.GetById(personId);
            dto.Should().NotBeNull();

            dto.Name = name;

            await _personService.Update(dto);
            var updatedDto = await _personService.GetById(personId);

            updatedDto.Should().NotBeNull();
            updatedDto.Name.Should().Be(name);
        }
        [Fact, Priority(5)]
        public async void Should_return_companies_by_Name()
        {
            var searchTerm = "John";
            var persons = await _personService.GetByName(searchTerm);
            persons.Should().NotBeNull();
            persons.Count.Should().NotBe(0);
        }
        [Theory, Priority(6)]
        [InlineData(1)]
        public async void Delete_Person(int personId)
        {
            await _personService.Delete(personId);
            var person = await _personService.GetById(personId);
            person.Should().BeNull();
        }
    }
}
