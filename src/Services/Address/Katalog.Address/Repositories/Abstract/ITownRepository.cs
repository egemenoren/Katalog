using Katalog.Address.Entities;

namespace Katalog.Address.Repositories.Abstract
{
    public interface ITownRepository:IBaseRepository<Town>
    {
        Task<bool> CheckTownExistsByCityId(string cityId, string townName);
    }
}
