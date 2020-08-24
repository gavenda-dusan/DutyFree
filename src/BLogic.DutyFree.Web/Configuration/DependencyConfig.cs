using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DutyFree.Data.EntityFramework;
using DutyFree.Core.Services.Products;
using DutyFree.Data.Repositories.Products;
using DutyFree.Web.Configuration.AutoMapper.Mappers.Products;
using DutyFree.Web.Configuration.AutoMapper.Profiles.Products;
using System.Reflection;
using System.Web.Mvc;
using DutyFree.Web.AppServices.Products;

namespace DutyFree.Web.Configuration
{
    public class DependencyConfig
    {
        protected readonly ContainerBuilder Builder;

        public DependencyConfig()
        {
            Builder = new ContainerBuilder();

            Configure();
        }

        public IContainer BuildContainer()
        {
            var container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private void Configure()
        {
            RegisterData();
            RegisterCore();
            RegisterApplication();
            RegisterAutoMapper();
            RegisterEntityFramework();
        }

        private void RegisterAutoMapper()
        {
            Builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductsProfile))).As<Profile>().SingleInstance();
            Builder.Register(AutoMapperConfig.Configure).As<IMapper>().SingleInstance();
            Builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductsMapper))).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void RegisterApplication()
        {
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            Builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductAppService))).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void RegisterCore()
        {
            Builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductService))).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void RegisterData()
        {
            Builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ProductRepository))).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private void RegisterEntityFramework()
        {
            Builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}