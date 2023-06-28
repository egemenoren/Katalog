using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Entities.Abstract;
using Katalog.Address.Repositories.Abstract;
using MongoDB.Driver;

namespace Katalog.Address.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T:class,IBaseEntity,new()
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

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMany(List<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
