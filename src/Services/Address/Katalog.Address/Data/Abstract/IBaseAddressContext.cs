using Katalog.Address.Entities.Abstract;
using MongoDB.Driver;

namespace Katalog.Address.Data.Abstract
{
    public interface IBaseAddressContext<T> where T : class,IBaseEntity,new()
    {
        IMongoCollection<T> TEntity { get; }
    }
}
