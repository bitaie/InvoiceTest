using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Insert(T entity);
        Task<int> InsertAsync(T entity);
        void Add(T entity);
        void Update(T entity);
        Task<int> UpdateAsync(T entity);
        void Delete(T entity);
        Task<int> DeleteAsync(T entity);
        void Remove(T entity);
        void SaveChanges();
        Task<int> SaveChangesAsync();
        bool Exists(int id);
    }
}
