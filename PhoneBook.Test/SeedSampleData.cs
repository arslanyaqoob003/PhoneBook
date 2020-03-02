using PhoneBook.Core.Domain;
using PhoneBook.Infrastructure;
using System;

namespace PhoneBook.Test
{
    /// <summary>
    /// To seed the inittial data in mempry which is used in Test cases to validate the expected output
    /// </summary>
    public static class TestData
    {
        public static void SeedSampleData(this PhoneBookContext context)
        {
            context.Companies.AddRange(
                new Company
                {
                    Id = 1,
                    Name = "Test Company",
                    Site = "www.allianstrafikskola.se",
                    Address = "Danmarksgatan 4616440 KISTA",
                    City = "Cairo",
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
                     City = "Manhatten",
                     DateOfCreation = new DateTime(2008, 6, 1),
                     Rating = 5,
                     TelephoneNumber = "0767895436",
                     Latitude = 12.56512,
                     Longitude = 80.56756,
                     Summary = "All around the world, we provided best quality socks",

                 }

            );

            context.Persons.AddRange(
                new Person
                {
                    Id = 1,
                    Name = "Arslan Yaqoob",
                    Address = "Berlin 4212",
                    DateOfBirth = new DateTime(1994, 6, 1),
                    City = "Cairo",
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
                    City = "Manhatten",
                    TelephoneNumber = "0767345436",
                    Latitude = 90.56512,
                    Longitude = 10.56756,
                }
            );

            context.SaveChanges();
        }
    }

}
