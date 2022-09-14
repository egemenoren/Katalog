﻿using Katalog.Product.Data.Abstract;
using Katalog.Product.Entities.Abstract;
using Katalog.Product.Repositories.Abstract;
using Katalog.Shared;
using MongoDB.Driver;

namespace Katalog.Product.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        #region Constructor
        private readonly IBaseProductContext<TEntity> _context;

        public BaseRepository(IBaseProductContext<TEntity> context)
        {
            _context = context;
        }
        #endregion

        #region CRUD OPERATIONS
        public async Task Create(TEntity entity)
        {
            await _context.TEntity.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _context.TEntity.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteMany(List<string> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                var filter = Builders<TEntity>.Filter.Eq(x => x.Id, ids[i]);
                DeleteResult deleteResult = await _context.TEntity.DeleteOneAsync(filter);
                if (deleteResult.IsAcknowledged == false && deleteResult.DeletedCount == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<ResponseDto<TEntity>> GetById(string id)
        {
            var data = await _context.TEntity.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (data != null)
                return ResponseDto<TEntity>.Success(data, 1);
            else
                return null;
        }

        public async Task<ResponseDto<List<TEntity>>> GetAll()
        {
            var data = await _context.TEntity.Find(p => true).ToListAsync();
            return ResponseDto<List<TEntity>>.Success(data, 1);
        }

        public async Task<bool> Update(TEntity entity)
        {
            var updateResult = await _context.TEntity.ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> UpdateMany(List<TEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var updateResult = await _context.TEntity.ReplaceOneAsync(filter: g => g.Id == entities[i].Id, replacement: entities[i]);
                if (updateResult.IsAcknowledged == false && updateResult.ModifiedCount == 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
