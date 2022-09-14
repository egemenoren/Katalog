using Katalog.Product.Entities.Abstract;
using MongoDB.Driver;

namespace Katalog.Product.Data.Abstract
{
    public interface IBaseProductContext<T> where T : class,IEntity,new()
    {
        IMongoCollection<T> TEntity { get; }
    }
}
