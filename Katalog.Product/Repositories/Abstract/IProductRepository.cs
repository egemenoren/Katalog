using MongoDB.Bson;

namespace Katalog.Product.Repositories.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts();
        Task<Entities.Product> GetProduct(string id);
        Task<IEnumerable<Entities.Product>> GetProductByName(string name);
        Task<IEnumerable<Entities.Product>> GetProductByCategory(string categoryName);


        Task Create(Entities.Product product);
        Task<bool> Update(Entities.Product product);
        Task<bool> UpdateMany(List<Entities.Product> products);
        Task<bool> Delete(string id);
        Task<bool> DeleteMany(List<string> ids);
    }
}
