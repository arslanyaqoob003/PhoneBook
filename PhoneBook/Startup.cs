using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneBook.Application.Companies;
using PhoneBook.Application.Persons;
using PhoneBook.Infrastructure;
using PhoneBook.Infrastructure.Repository;

namespace PhoneBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Initilized in memory database
            services.AddDbContext<PhoneBookContext>(options => options.UseInMemoryDatabase(databaseName: "PhoneBook"));

            // configurations of IMapper that map data transfer objects to domain models
            services.AddAutoMapper(cfg=> 
            {
                cfg.CreateMissingTypeMaps = true;
            });

           // register repositories
           services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            // register services
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IPersonService, PersonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
