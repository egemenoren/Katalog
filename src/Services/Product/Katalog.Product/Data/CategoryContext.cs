using Katalog.Product.Data.Abstract;
using Katalog.Product.Settings;
using MongoDB.Driver;

namespace Katalog.Product.Data
{
    public class CategoryContext : IBaseProductContext<Entities.Category>
    {
        public CategoryContext(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionStrings);
            var database = client.GetDatabase(settings.DatabaseName);

            TEntity = database.GetCollection<Entities.Category>(settings.CategoriesCollectionName);
        }
        public IMongoCollection<Entities.Category> TEntity { get; }
    }
}
