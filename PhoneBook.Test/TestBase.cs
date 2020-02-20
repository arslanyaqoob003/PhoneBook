using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Infrastructure;
using Xunit;

namespace PhoneBook.Test
{
    /// <summary>
    /// contains Shared functionality of all the Test classes
    /// </summary>
    public class TestBase : IClassFixture<Fixture>
    {
        public ServiceProvider Services; // IOC container to get the requred service
        public PhoneBookContext Context { get; private set; } // Unit of work
        public TestBase(Fixture fixture)
        {
            Services = fixture.ServiceProvider;
            Context = Services.GetService<PhoneBookContext>();
            if (Context.Database.EnsureCreated())
                Context.SeedSampleData();

        }
        public static void Destroy(PhoneBookContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
