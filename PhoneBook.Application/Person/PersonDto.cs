using System;

namespace PhoneBook
{
    public class PersonDto
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public double Longitude {get;set; }
         public double Latitude  {get;set; }
    }
}
