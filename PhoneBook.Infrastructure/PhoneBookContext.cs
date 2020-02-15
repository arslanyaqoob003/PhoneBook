using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain;

namespace PhoneBook.Infrastructure
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
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
