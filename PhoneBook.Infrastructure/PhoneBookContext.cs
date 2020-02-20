using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain;

namespace PhoneBook.Infrastructure
{
    // Framework dependent Implementation of Unit of work
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; } // Framework dependent Implementation of Companies Repository Pattern
        public DbSet<Person> Persons { get; set; } // Framework dependent Implementation of Persons Repository Pattern
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Person>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();
        }
    }
}
