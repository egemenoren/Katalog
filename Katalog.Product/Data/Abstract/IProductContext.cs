using MongoDB.Driver;

namespace Katalog.Product.Data.Abstract
{
    public interface IProductContext
    {
        IMongoCollection<Entities.Product> Products { get; }
    }
}
