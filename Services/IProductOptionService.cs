using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductOptionService : IService<ProductOption>
    {
        IList<ProductOption> GetOptionsByProductId(Guid productId);
    }
}
