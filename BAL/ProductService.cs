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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> ProductRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            ProductRepository = productRepository;
        }

        public void Create(Product product)
        {
            ProductRepository.Insert(product);
        }

        public void Delete(Guid id)
        {
            ProductRepository.Delete(id);
        }

        public Product Get(Guid id)
        {
            return ProductRepository.Get(id);
        }

        public IList<Product> GetAll()
        {
            return ProductRepository.GetAll().ToList();
        }

        public IList<Product> SearchByName(string name)
        {
            return ProductRepository.GetAll()
                .Where(product => product.Name == name)
                .ToList();
        }

        public void Update(Product product)
        {
            ProductRepository.Update(product);
            ProductRepository.Save();
        }
    }
}
