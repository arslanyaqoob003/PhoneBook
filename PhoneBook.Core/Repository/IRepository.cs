using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Domain;

public interface IRepository<T> where T : Entity  
    {
        IEnumerable<T> Get();  
        Task<T> Get(long id);
        Task<T> Insert(T entity);  
        Task Update(T entity);  
        Task Delete(int id);  
    }  