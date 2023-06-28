using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Repositories.Abstract;

namespace Katalog.Address.Repositories
{
    public class AddressRepository:BaseRepository<Entities.Address>,IAddressRepository
    {
        private readonly IBaseAddressContext<Entities.Address> _context;
        public AddressRepository(IBaseAddressContext<Entities.Address> context) : base(context)
        {
            _context = context;
        }
    }
}
