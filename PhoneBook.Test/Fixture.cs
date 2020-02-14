using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Companies;
using PhoneBook.Application.PersonAndCompany;
using PhoneBook.Application.Persons;
using PhoneBook.Core.Domain;
using PhoneBook.Infrastructure;
using PhoneBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Test
{
    // Provides only dependecies required by the unit test class
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

            ServiceProvider = services.BuildServiceProvider();
            Context = ServiceProvider.GetService<PhoneBookContext>();
        }

    }
}
