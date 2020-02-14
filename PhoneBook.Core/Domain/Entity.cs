using System;

namespace PhoneBook.Domain
{
    public class Entity
    {
        public int Id {get;set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}