using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Domain;
using PhoneBook.Infrastructure;
using System;
using Xunit;

namespace PhoneBook.Test
{
    public class TestBase : IClassFixture<Fixture>
    {
        public ServiceProvider Services;
        public PhoneBookContext Context { get; private set; }
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
