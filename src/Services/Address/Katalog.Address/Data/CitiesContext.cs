using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Settings;
using MongoDB.Driver;

namespace Katalog.Address.Data
{
    public class CitiesContext : IBaseAddressContext<City>
    {
        public CitiesContext(IAddressDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.City>(settings.CitiesCollectionName);
        }
        public IMongoCollection<Entities.City> TEntity { get; }
    }
}
