using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Repositories.Abstract;
using MongoDB.Driver;

namespace Katalog.Address.Repositories
{
    public class AddressRepository:BaseRepository<Entities.Address>,IAddressRepository
    {
        private readonly IBaseAddressContext<Entities.Address> _context;
        public AddressRepository(IBaseAddressContext<Entities.Address> context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Entities.Address>> GetAddressesByUserId(string userId)
        {
            var result = await _context.TEntity.Find(x => x.UserId == userId).ToListAsync();
            return result;
        }
    }
}
