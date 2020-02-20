using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Application.Companies
{
    // DTO means Data Transfer Object
    // DTO and domain Models must be seperate in order to increase decouping and flexibility
    // Also contains validation rules
    // This is Company DTO which can be used to exchange data to\from services (Application Layer)
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string Site { get; set; }
        public int Rating { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public string Summary { get; set; }
    }
}
