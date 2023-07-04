using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Entities.Abstract;
using Katalog.Address.Repositories.Abstract;
using MongoDB.Driver;

namespace Katalog.Address.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {

        private readonly IBaseAddressContext<T> _context;

        public BaseRepository(IBaseAddressContext<T> context)
        {
            _context = context;
        }
        public virtual async Task Create(T entity)
        {

            await _context.TEntity.InsertOneAsync(entity);
        }

        public async Task CreateMany(List<T> entity)
        {
            await _context.TEntity.InsertManyAsync(entity);
        }

        public virtual async Task<bool> Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _context.TEntity.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteMany(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                var filter = Builders<T>.Filter.Eq(x => x.Id, ids[i]);
                DeleteResult deleteResult = await _context.TEntity.DeleteOneAsync(filter);
                if (deleteResult.IsAcknowledged == false && deleteResult.DeletedCount == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _context.TEntity.Find(x=>true).ToListAsync();
            return result;
        }

        public async Task<T> GetById(string id)
        {
            var result = await _context.TEntity.Find(x => x.Id == id).SingleOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(T entity)
        {
            var updateResult = await _context.TEntity.ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateMany(List<T> entity)
        {
            bool overallResult = true;
            for (int i = 0; i < entity.Count; i++)
            {
                var updateResult = await _context.TEntity.ReplaceOneAsync(x=>x.Id == entity[i].Id, entity[i]);
                if(!(updateResult.IsAcknowledged && updateResult.ModifiedCount > 0))
                    overallResult = false;
            }
            return overallResult;
        }
    }
}
