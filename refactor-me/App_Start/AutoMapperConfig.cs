using AutoMapper;
using refactor_me.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Database.Models.Product, Product>();
                cfg.CreateMap<Product, Database.Models.Product>();
                cfg.CreateMap<Database.Models.ProductOption, ProductOption>();
                cfg.CreateMap<ProductOption, Database.Models.ProductOption>();
            });
        }
    }
}