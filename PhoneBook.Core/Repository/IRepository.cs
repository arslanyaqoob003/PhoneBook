using System.Collections.Generic;
using PhoneBook.Domain;

public interface IRepository<T> where T : Entity  
    {  
        IEnumerable<T> GetAll();  
        T Get(long id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity);  
        void Remove(T entity);  
        void SaveChanges();  
    }  