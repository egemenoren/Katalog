using Katalog.Product.Data.Abstract;
using Katalog.Product.Settings;
using MongoDB.Driver;

namespace Katalog.Product.Data
{
    public class BrandContext : IBaseProductContext<Entities.Brand>
    {
        public BrandContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.Brand>(settings.BrandsCollectionName);
        }
        public IMongoCollection<Entities.Brand> TEntity { get; }
    }
}
