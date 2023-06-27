using Katalog.Discount.Entities;
using Katalog.Shared.Dtos;

namespace Katalog.Discount.Services
{
    public interface IDiscountService
    {
        Task<ResponseDto<Entities.Discount>> GetById(int id);
        Task<ResponseDto<Entities.Discount>> GetByUserIdAndCode(string code,string userId);
        Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByCode(string code);
        Task<ResponseDto<IEnumerable<Entities.Discount>>> GetAll();
        Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByStoreIds(string[] storeIds);
        Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByCategoryIds(string[] categoryIds);
        Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByProductIds(string[] productIds);
        Task<ResponseDto> Create(Entities.Discount discount);
        Task<ResponseDto> Update(Entities.Discount discount);
        Task<ResponseDto> Remove(int id);
        Task<ResponseDto> UseCode(string code);
    }
}
