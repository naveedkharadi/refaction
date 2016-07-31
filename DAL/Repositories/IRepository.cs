using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T Get(Guid id);
        IQueryable<T> GetAll();
        T Insert(T o);
        void Update(T o);
        void Save();
        void Delete(Guid id);
    }
}
