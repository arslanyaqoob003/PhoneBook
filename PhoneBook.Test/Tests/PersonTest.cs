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
    /// <summary>
    /// Contains all the test cases of persons
    /// </summary>
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
            var name = "Arslan Pansota";
            var dto = new PersonDto
            {
                Name = name,
                Address = "Denmark 4616440 KISTA",
                DateOfBirth = new DateTime(1994, 3, 1),
                City = "California",
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
            var name = "Ar";
            personId.Should().NotBe(0);

            var dto = await _personService.GetById(personId);
            dto.Should().NotBeNull();

            dto.Name = name;

            await _personService.Update(dto);
            var updatedDto = await _personService.GetById(personId);

            updatedDto.Should().NotBeNull();
            updatedDto.Name.Should().Be(name);
        }

        public static object[][] PersonData =
        {
            new object[] {"ar", null,null,null, 2 },
            new object[] {null, "ca", null, null, 2 },
            new object[] {null, null,null, new DateTime(1994, 7, 1), 3 },
            new object[] {null, null, new DateTime(1960, 6, 1), new DateTime(1994, 7, 1), 3 },
            new object[] {"Arslan", "ca", new DateTime(1960, 6, 1), new DateTime(1994, 7, 1), 1 },
            new object[] {null, null, new DateTime(1960, 6, 1), new DateTime(1994, 1, 1), 1 },
            new object[] {null, null, new DateTime(1960, 6, 1),null, 3 },
            new object[] {null, null,null,null, 3 },
        };
        [Theory, Priority(6), MemberData(nameof(PersonData))]
        public async void Should_return_persons_by_Name_and_City(string name, string city, DateTime? dobStart, DateTime? dobEnd, int expect)
        {
            var persons = await _personService.Get(name, city, dobStart, dobEnd);
            persons.Should().NotBeNull();
            persons.Count.Should().NotBe(0);
            persons.Count.Should().Be(expect);
        }
        [Theory, Priority(7)]
        [InlineData(1)]
        public async void Delete_Person(int personId)
        {
            await _personService.Delete(personId);
            var person = await _personService.GetById(personId);
            person.Should().BeNull();
        }
    }
}