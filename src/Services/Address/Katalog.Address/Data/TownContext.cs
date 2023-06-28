using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Settings;
using MongoDB.Driver;

namespace Katalog.Address.Data
{
    public class TownContext:IBaseAddressContext<Town>
    {
        public TownContext(IAddressDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.Town>(settings.TownsCollectionName);
        }
        public IMongoCollection<Entities.Town> TEntity { get; }
    }
}
