using Autofac;
using Katalog.Product.Data;
using Katalog.Product.Data.Abstract;
using Katalog.Product.Repositories;
using Katalog.Product.Repositories.Abstract;

namespace Katalog.Product.DependencyResolvers.Autofac
{
    public class AutofacProductServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductContext>().As<IBaseProductContext<Entities.Product>>().SingleInstance();
            builder.RegisterType<BrandContext>().As<IBaseProductContext<Entities.Brand>>().SingleInstance();
            builder.RegisterType<CategoryContext>().As<IBaseProductContext<Entities.Category>>().SingleInstance();

            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();
        }
    }
}
