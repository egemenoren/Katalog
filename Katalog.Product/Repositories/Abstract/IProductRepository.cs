using MongoDB.Bson;

namespace Katalog.Product.Repositories.Abstract
{
    public interface IProductRepository : IBaseRepository<Entities.Product>
    {
        Task<IEnumerable<Entities.Product>> GetProductByCategory(string categoryName);
    }
}
