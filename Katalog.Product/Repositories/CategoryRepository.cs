using Katalog.Product.Data.Abstract;
using Katalog.Product.Entities;
using Katalog.Product.Repositories.Abstract;

namespace Katalog.Product.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        IBaseProductContext<Entities.Category> _context;
        public CategoryRepository(IBaseProductContext<Category> context) : base(context)
        {
            _context = context;
        }
    }
}
