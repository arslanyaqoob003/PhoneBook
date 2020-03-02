using System;
using PhoneBook.Domain;

namespace PhoneBook.Core.Domain
{
    // Core omain model of Person
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string TelephoneNumber { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
