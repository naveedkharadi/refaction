using Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly RefactorMeModel context;
        private bool disposed;

        public Repository(RefactorMeModel RefactorMeModel)
        {
            context = RefactorMeModel;
        }

        public T Get(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T Insert(T o)
        {
            var result = context.Set<T>().Add(o);
            
            return result;
        }

        public void Update(T o)
        {
            context.Entry(o).State = EntityState.Modified;
        }

        public void Save()
        {
            List<Object> modifiedOrAddedEntities = context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified
                            || x.State == EntityState.Added
                            || x.State == EntityState.Deleted)
                .Select(x => x.Entity).ToList();

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var existing = context.Set<T>().Find(id);
            if (existing != null)
            {
                context.Set<T>().Remove(existing);
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
