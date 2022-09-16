using Katalog.Product.Entities.Abstract;
using Katalog.Shared;

namespace Katalog.Product.Repositories.Abstract
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntity,new()
    {
        Task<ResponseDto<List<TEntity>>> GetAll();
        Task<ResponseDto<TEntity>> GetById(string id);

        Task Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> UpdateMany(List<TEntity > entity);
        Task<bool> Delete(string id);
        Task<bool> DeleteMany(List<string> ids);
    }
}
