﻿using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructure
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}