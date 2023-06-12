using Katalog.Discount.Entities;

namespace Katalog.Discount.Repository
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Entities.Discount>> GetAll();
        Task<Entities.Discount> GetById(int id);
        Task<bool> Update(Entities.Discount discount);
        Task<bool> Create(Entities.Discount discount);
        Task<bool> Delete(int id);
    }
}
