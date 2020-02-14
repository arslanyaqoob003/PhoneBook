using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Exceptions;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity,new()
    {
        protected readonly PhoneBookContext context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(PhoneBookContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> Get()
        {
            return entities.AsEnumerable();
        }

        public Task<T> Get(long id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
           await context.SaveChangesAsync();
           return entity;
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
           return context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                throw new NotFoundException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public Task SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}