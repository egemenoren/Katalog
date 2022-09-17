using Katalog.Product.Data.Abstract;
using Katalog.Product.Repositories.Abstract;

namespace Katalog.Product.Repositories
{
    public class ProductRepository : BaseRepository<Entities.Product>, IProductRepository
    {
        private IBaseProductContext<Entities.Product> _context;

        public ProductRepository(IBaseProductContext<Entities.Product> context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Entities.Product>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public override async Task Create(Entities.Product entity)
        {
            await base.Create(entity);
        }
    }
}