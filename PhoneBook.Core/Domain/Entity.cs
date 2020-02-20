using System;

namespace PhoneBook.Domain
{
    // Base class which is shared by every domain model
    public class Entity
    {
        public int Id {get;set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}