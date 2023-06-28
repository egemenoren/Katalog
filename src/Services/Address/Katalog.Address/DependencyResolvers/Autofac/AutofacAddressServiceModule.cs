using Autofac;
using Katalog.Address.Data;
using Katalog.Address.Data.Abstract;
using Katalog.Address.Repositories;
using Katalog.Address.Repositories.Abstract;
using Katalog.Address.Services;

namespace Katalog.Address.DependencyResolvers.Autofac
{
    public class AutofacAddressServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AddressContext>().As<IBaseAddressContext<Entities.Address>>().SingleInstance();
            builder.RegisterType<CitiesContext>().As<IBaseAddressContext<Entities.City>>().SingleInstance();
            builder.RegisterType<TownContext>().As<IBaseAddressContext<Entities.Town>>().SingleInstance();

            builder.RegisterType<AddressRepository>().As<IAddressRepository>().SingleInstance();
            builder.RegisterType<TownRepository>().As<ITownRepository>().SingleInstance();
            builder.RegisterType<CityRepository>().As<ICityRepository>().SingleInstance();
            builder.RegisterType<WriteDatasToDb>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();





        }
    }
}
