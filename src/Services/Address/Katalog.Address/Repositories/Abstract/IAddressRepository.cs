using Katalog.Address.Entities;

namespace Katalog.Address.Repositories.Abstract
{
    public interface IAddressRepository:IBaseRepository<Entities.Address>
    {
        Task<List<Entities.Address>> GetAddressesByUserId(string userId);
    }
}
