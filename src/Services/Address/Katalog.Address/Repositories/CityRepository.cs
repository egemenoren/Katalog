using Katalog.Address.Data;
using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Repositories.Abstract;
using MongoDB.Driver;

namespace Katalog.Address.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly IBaseAddressContext<City> _context;
        public CityRepository(IBaseAddressContext<City> context) : base(context)
        {
            _context = context;
        }
        public async Task<City> GetByName(string name)
        {
            var filter = Builders<City>.Filter.Where(x=>x.Name == name);
           return await _context.TEntity.Find(filter).FirstOrDefaultAsync();
        }
    }
}
