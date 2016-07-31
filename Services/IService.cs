using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
        T Get(Guid id);
        IList<T> GetAll();
    }
}
