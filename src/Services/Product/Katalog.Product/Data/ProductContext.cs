using Katalog.Product.Data.Abstract;
using Katalog.Product.Settings;
using MongoDB.Driver;

namespace Katalog.Product.Data
{
    public class ProductContext : IBaseProductContext<Entities.Product>
    {
        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.Product>(settings.ProductsCollectionName);
        }
        public IMongoCollection<Entities.Product> TEntity { get; }
    }
}
