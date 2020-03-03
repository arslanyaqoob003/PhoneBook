using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Companies;
using PhoneBook.Application.Extensions;
using PhoneBook.Application.PersonAndCompany;
using PhoneBook.Application.Persons;
using PhoneBook.Core.Parser;
using PhoneBook.Core.Parser.Factory;
using PhoneBook.Infrastructure;
using PhoneBook.Infrastructure.Parser;
using PhoneBook.Infrastructure.Repository;
using System;

namespace PhoneBook.Test
{
    /// <summary>
    /// Used to register in IOC continer, all the dependencies required by Test classes
    /// </summary>
    public class Fixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public PhoneBookContext Context { get;  private set; }
        public Fixture()
        {
            var services = new ServiceCollection();
            // Initilized in memory database
            services
                .AddDbContext<PhoneBookContext>(options =>  options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // configurations of IMapper that map data transfer objects to domain models
            var mapper = new MapperConfiguration(cfg =>{
                cfg.CreateMissingTypeMaps = true;
            }).CreateMapper();
            services.AddScoped(x=> mapper);


            // register repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            // register services
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ICompanyPersonAggrigateService, CompanyPersonAggrigateService>();

            // string parsers
            services.RegisterStringParseFactory("PhoneBook.Infrastructure");
            services.AddTransient<IParser,CsvParser>();
            // IOC container
            ServiceProvider = services.BuildServiceProvider();
            Context = ServiceProvider.GetService<PhoneBookContext>();
        }

    }
}
