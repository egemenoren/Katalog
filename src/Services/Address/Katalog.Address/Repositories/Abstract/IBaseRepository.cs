using Katalog.Address.Entities.Abstract;

namespace Katalog.Address.Repositories.Abstract
{
    public interface IBaseRepository<T> where T :class,IBaseEntity, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task CreateMany(List<T> entity);
        Task<bool> Update(T entity);
        Task<bool> UpdateMany(List<T> entity);
        Task<bool> Delete(string id);
        Task<bool> DeleteMany(List<string> ids);
    }
}
