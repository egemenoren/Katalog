using Katalog.Address.Data.Abstract;
using Katalog.Address.Entities;
using Katalog.Address.Repositories.Abstract;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Katalog.Address.Repositories
{
    public class TownRepository:BaseRepository<Town>,ITownRepository
    {
        private readonly IBaseAddressContext<Town> _context;
        public TownRepository(IBaseAddressContext<Town> context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> CheckTownExistsByCityId(string cityId,string townName)
        {
            var filter = Builders<Town>.Filter.Where(x => x.Name == townName && x.CityId == cityId);
            return await _context.TEntity.Find(filter).AnyAsync();
        }
    }
}
