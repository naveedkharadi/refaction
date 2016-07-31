using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using Services;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductService ProductService;
        private IProductOptionService ProductOptionService;

        public ProductsController()
        {
            ProductService = (IProductService)DependencyInjectionConfig.Resolver.GetService(typeof(IProductService));
            ProductOptionService = (IProductOptionService)DependencyInjectionConfig.Resolver.GetService(typeof(IProductOptionService));
        }

        [Route]
        [HttpGet]
        public IList<Product> GetAll()
        {
            IList<Product> listOfUIProducts = new List<Product>();
            var listOfProducts = ProductService.GetAll();
            listOfUIProducts = AutoMapper.Mapper.Map(listOfProducts, listOfUIProducts);
            return listOfUIProducts;
        }

        [Route]
        [HttpGet]
        public IList<Product> SearchByName(string name)
        {
            IList<Product> listOfUIProducts = new List<Product>();
            var listOfProducts = ProductService.SearchByName(name);
            listOfUIProducts = AutoMapper.Mapper.Map(listOfProducts, listOfUIProducts);
            return listOfUIProducts;
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            var product = ProductService.Get(id);
            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Product uiProduct = AutoMapper.Mapper.Map<Product>(product);
            return uiProduct;
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            if (product != null)
            {
                Database.Models.Product dbProduct = AutoMapper.Mapper.Map<Database.Models.Product>(product);
                ProductService.Create(dbProduct);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            if (product != null)
            {
                Database.Models.Product dbProduct = ProductService.Get(id);
                if (dbProduct != null)
                {
                    dbProduct = AutoMapper.Mapper.Map<Database.Models.Product>(product);
                    dbProduct.Id = id;
                    ProductService.Update(dbProduct);
                }
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            ProductService.Delete(id);
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IList<ProductOption> GetOptions(Guid productId)
        {
            IList<ProductOption> listOfUIProductOptions = new List<ProductOption>();
            var listOfProductOptions = ProductOptionService.GetOptionsByProductId(productId);
            listOfUIProductOptions = AutoMapper.Mapper.Map(listOfProductOptions, listOfUIProductOptions);
            return listOfUIProductOptions;
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var productOption = ProductOptionService.Get(id);
            if (productOption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ProductOption uiProductOption = AutoMapper.Mapper.Map<ProductOption>(productOption);
            return uiProductOption;
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            if (option != null)
            {
                Database.Models.ProductOption dbProductOption = AutoMapper.Mapper.Map<Database.Models.ProductOption>(option);
                dbProductOption.ProductId = productId;
                ProductOptionService.Create(dbProductOption);
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            if (option != null)
            {
                Database.Models.ProductOption dbProductOption = ProductOptionService.Get(id);
                if (dbProductOption != null)
                {
                    dbProductOption = AutoMapper.Mapper.Map<Database.Models.ProductOption>(option);
                    dbProductOption.Id = id;
                    ProductOptionService.Update(dbProductOption);
                }
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            ProductOptionService.Delete(id);
        }
    }
}
