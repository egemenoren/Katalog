using Katalog.Product.Data.Abstract;
using Katalog.Product.Repositories.Abstract;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Katalog.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Constructor
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context;
        }
        #endregion

        #region CRUD OPERATIONS
        public async Task Create(Entities.Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteMany(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                var filter = Builders<Entities.Product>.Filter.Eq(x => x.Id, ids[i]);
                DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
                if (deleteResult.IsAcknowledged == false && deleteResult.DeletedCount ==0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Entities.Product> GetProduct(string id)
        {
            return await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductByCategory(string categoryId)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(x => x.CategoryId, categoryId);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProductByName(string name)
        {
            var filter = Builders<Entities.Product>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Entities.Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> UpdateMany(List<Entities.Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == products[i].Id, replacement: products[i]);
                if (updateResult.IsAcknowledged ==false && updateResult.ModifiedCount ==0)
                {
                    return false;
                }
            } 
            return true;
        }
        #endregion
    }
}
