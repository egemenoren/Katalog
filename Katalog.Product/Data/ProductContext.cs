using Katalog.Product.Data.Abstract;
using Katalog.Product.Settings;
using MongoDB.Driver;

namespace Katalog.Product.Data
{
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Entities.Product>(settings.ProductsCollectionName);
            Brands = database.GetCollection<Entities.Brand>(settings.BrandsCollectionName);
            Categories = database.GetCollection<Entities.Category>(settings.CategoriesCollectionName);
        }
        public IMongoCollection<Entities.Product> Products { get; }
        public IMongoCollection<Entities.Brand> Brands { get; }
        public IMongoCollection<Entities.Category> Categories { get; }
    }
}
