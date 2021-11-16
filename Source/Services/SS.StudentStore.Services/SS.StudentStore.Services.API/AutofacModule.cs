using Autofac;
using AutoMapper;
using SS.StudentStore.Services.Core.Interfaces.Helper;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Services;
using SS.StudentStore.Services.Infrastructure.DBContext;
using SS.StudentStore.Services.Infrastructure.Helper;
using SS.StudentStore.Services.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterInstance(new AutoMapperConfiguration().Configure()).As<IMapper>();
            builder.Register(r => new ProductProvider(r.Resolve<CoreDBContext>())).As<IProductProvider>().InstancePerLifetimeScope();
            builder.Register(r => new ProductTypeProvider(r.Resolve<CoreDBContext>())).As<IProductTypeProvider>().InstancePerLifetimeScope();
            builder.Register(r => new ProductTypeMappingProvider(r.Resolve<CoreDBContext>())).As<IProductTypeMappingProvider>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            
            builder.Register(r => new CategoryProvider(r.Resolve<CoreDBContext>())).As<ICategoryProvider>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();

            builder.Register(r => new SubCategoryProvider(r.Resolve<CoreDBContext>())).As<ISubCategoryProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>().InstancePerLifetimeScope();

            builder.Register(r => new SectionProvider(r.Resolve<CoreDBContext>())).As<ISectionProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SectionService>().As<ISectionService>().InstancePerLifetimeScope();

            builder.Register(r => new GradeProvider(r.Resolve<CoreDBContext>())).As<IGradeProvider>().InstancePerLifetimeScope();
            builder.RegisterType<GradeService>().As<IGradeService>().InstancePerLifetimeScope();

            builder.Register(r => new BrandProvider(r.Resolve<CoreDBContext>())).As<IBrandProvider>().InstancePerLifetimeScope();
            builder.RegisterType<BrandService>().As<IBrandService>().InstancePerLifetimeScope();

            builder.Register(r => new BasketProvider(r.Resolve<StoreDBContext>())).As<IBasketProvider>().InstancePerLifetimeScope();
            builder.RegisterType<BasketService>().As<IBasketService>().InstancePerLifetimeScope();


            builder.Register(r => new UserProvider(r.Resolve<AppIdentityDBContext>())).As<IUserProvider>().InstancePerLifetimeScope();
            builder.Register(r => new AddressProvider(r.Resolve<AppIdentityDBContext>())).As<IAddressProvider>().InstancePerLifetimeScope();
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();

            builder.RegisterType<ConfigurationHelper>().As<IConfigurationHelper>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();


            builder.Register(r => new DeliveryMethodProvider(r.Resolve<OrderDBContext>())).As<IDeliveryMethodProvider>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();

            builder.Register(r => new OrderProvider(r.Resolve<OrderDBContext>())).As<IOrderProvider>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();

            builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}
