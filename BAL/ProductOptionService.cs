using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using DAL.Repositories;

namespace BAL
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IRepository<ProductOption> ProductOptionRepository;

        public ProductOptionService(IRepository<ProductOption> productOptionRepository)
        {
            ProductOptionRepository = productOptionRepository;
        }

        public void Create(ProductOption ProductOption)
        {
            ProductOptionRepository.Insert(ProductOption);
        }

        public void Delete(Guid id)
        {
            ProductOptionRepository.Delete(id);
        }

        public ProductOption Get(Guid id)
        {
            return ProductOptionRepository.Get(id);
        }

        public IList<ProductOption> GetAll()
        {
            return ProductOptionRepository.GetAll().ToList();
        }

        public IList<ProductOption> GetOptionsByProductId(Guid productId)
        {
            return ProductOptionRepository.GetAll()
                .Where(ProductOption => ProductOption.ProductId == productId)
                .ToList();
        }

        public IList<ProductOption> SearchByName(string name)
        {
            return ProductOptionRepository.GetAll()
                .Where(ProductOption => ProductOption.Name == name)
                .ToList();
        }

        public void Update(ProductOption ProductOption)
        {
            ProductOptionRepository.Update(ProductOption);
            ProductOptionRepository.Save();
        }
    }
}
