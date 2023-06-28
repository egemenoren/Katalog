using Katalog.Address.Entities;

namespace Katalog.Address.Repositories.Abstract
{
    public interface ICityRepository:IBaseRepository<City>
    {
        Task<City> GetByName(string name);
    }
}
