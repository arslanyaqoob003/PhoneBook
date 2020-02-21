using System;
using PhoneBook.Domain;

namespace PhoneBook.Core.Domain
{
    // Core Domain model of Company
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string TelephoneNumber { get; set; }
        public string Site { get; set; }
        public int Rating { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Summary { get; set; }
    }
}
