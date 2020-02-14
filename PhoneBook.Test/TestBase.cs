using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Domain;
using PhoneBook.Infrastructure;
using System;
using Xunit;

namespace PhoneBook.Test
{
    public class TestBase : IClassFixture<Fixture>
    {
        public ServiceProvider Services;
        public PhoneBookContext Context { get; private set; }
        public TestBase(Fixture fixture)
        {
            Services = fixture.ServiceProvider;
            Context = Services.GetService<PhoneBookContext>();
            if (Context.Database.EnsureCreated())
                SeedSampleData(Context);

        }
        public static void SeedSampleData(PhoneBookContext context)
        {
            context.Companies.AddRange(
                new Company
                {
                    Id = 1,
                    Name = "Alliance Trafikskola AB",
                    Site = "www.allianstrafikskola.se",
                    Address = "Danmarksgatan 4616440 KISTA",
                    DateOfCreation = new DateTime(2007, 3, 1),
                    Rating = 5,
                    TelephoneNumber = "0761645436",
                    Latitude = 29.56512,
                    Longitude = 167.56756,
                    Summary = "Alliance Traffic School has its premises on Denmarksgatan 46 in Kista, just a stone's throw from Kista galle",

                },
                 new Company
                 {
                     Id = 2,
                     Name = "Mousee",
                     Site = "www.mousee.se",
                     Address = "Berlin 4212",
                     DateOfCreation = new DateTime(2008, 6, 1),
                     Rating = 5,
                     TelephoneNumber = "0767895436",
                     Latitude = 12.56512,
                     Longitude = 80.56756,
                     Summary = "All around the world, we provided best quality socks",

                 }

            );

            context.Person.AddRange(
                new Person
                {
                    Id = 1,
                    Name = "Arslan Yaqoob",
                    Address = "Berlin 4212",
                    DateOfBirth = new DateTime(1994, 6, 1),
                    TelephoneNumber = "0767895436",
                    Latitude = 12.56512,
                    Longitude = 80.56756,
                },
                new Person
                {
                    Id = 2,
                    Name = "John Doe",
                    Address = "Alliance Trafikskola AB",
                    DateOfBirth = new DateTime(1987, 6, 1),
                    TelephoneNumber = "0767345436",
                    Latitude = 90.56512,
                    Longitude = 10.56756,
                }
            );

            context.SaveChanges();
        }
        public static void Destroy(PhoneBookContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
