using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using Microsoft.EntityFrameworkCore;
using WebApplication1;


namespace DomainServices.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public async Task<T> GetAsync(int id)
        {
            return await entities.FindAsync(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            return await context.SaveChangesAsync();
        }
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
           
        }
        //@ToDo
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //if (this.Get(T.Id) == null)
            //{
            //    throw NotFound();
            //}
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
           return await context.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

       

        public bool Exists(int id)
        {
            if (this.Get(id) == null)
                return false;
            return true;
        }

       

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T entityInDb =this.Get(entity.Id);
            if (entityInDb == null)
            {
                throw new KeyNotFoundException();
            }
            context.Entry(entityInDb).CurrentValues.SetValues(entity);
            return await context.SaveChangesAsync();
        }
    }
    }


