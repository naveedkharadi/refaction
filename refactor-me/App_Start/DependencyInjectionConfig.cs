using Autofac;
using Autofac.Integration.WebApi;
using BAL;
using DAL.Repositories;
using Database.Models;
using refactor_me.Controllers;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace refactor_me
{
    public class DependencyInjectionConfig
    {
        public static IDependencyResolver Resolver;

        public static void Inject()
        {
            var cb = new ContainerBuilder();

            cb.RegisterType<RefactorMeModel>().InstancePerLifetimeScope();
            cb.RegisterType<Repository<Product>>().As<IRepository<Product>>().InstancePerLifetimeScope();
            cb.RegisterType<Repository<ProductOption>>().As<IRepository<ProductOption>>().InstancePerLifetimeScope();

            cb.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            cb.RegisterType<ProductOptionService>().As<IProductOptionService>().InstancePerLifetimeScope();

            cb.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerLifetimeScope();
            //cb.RegisterAssemblyModules(typeof(WebApiApplication).Assembly);

            var container = cb.Build();
            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            Resolver = config.DependencyResolver;
        }

        //public static IDependencyResolver Resolver()
        //{
        //    return GlobalConfiguration.Configuration.DependencyResolver;
        //}

    }

    //internal class AutofacWebAPI
    //{
    //    public static void Initialize()
    //    {
    //        var builder = new ContainerBuilder();
    //        GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebAPIDependencyResolver(RegisterServices(builder));
    //    }

    //    private static IContainer RegisterServices(ContainerBuilder builder)
    //    {
    //        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();

    //        builder.RegisterType<WordRepository>().As<IWordRepository>();
    //        builder.RegisterType<MeaningRepository>().As<IMeaningRepository>();

    //        return
    //            builder.Build();
    //    }
    //}

    //internal class AutofacWebAPIDependencyResolver : IDependencyScope, IDependencyResolver
    //{

    //    private readonly IContainer _container;

    //    public AutofacWebAPIDependencyResolver(IContainer container)
    //    {
    //        _container = container;
    //    }

    //    public IDependencyScope BeginScope()
    //    {
    //        return new AutofacWebApiDependencyResolver(;
    //    }

    //    public void Dispose()
    //    {
    //    }

    //    public object GetService(Type serviceType)
    //    {
    //        return _container.IsRegistered(serviceType) ? _container.Resolve(serviceType) : null;
    //    }

    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        Type enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
    //        object instance = _container.Resolve(enumerableServiceType);
    //        return ((IEnumerable)instance).Cast<object>();
    //    }
    //}
}