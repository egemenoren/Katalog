using Katalog.Address.Data.Abstract;
using Katalog.Address.Settings;
using MongoDB.Driver;

namespace Katalog.Address.Data
{
    public class AddressContext : IBaseAddressContext<Entities.Address>
    {
        public AddressContext(IAddressDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.Address>(settings.AddressesCollectionName);
        }
        public IMongoCollection<Entities.Address> TEntity { get; }
    }
}
