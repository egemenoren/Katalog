using Katalog.Product.Data.Abstract;
using Katalog.Product.Entities;
using Katalog.Product.Repositories.Abstract;

namespace Katalog.Product.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        IBaseProductContext<Brand> _context;
        public BrandRepository(IBaseProductContext<Brand> context) : base(context)
        {
            _context = context;
        }
    }
}
