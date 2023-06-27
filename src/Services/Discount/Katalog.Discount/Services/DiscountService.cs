using Katalog.Discount.Entities;
using Katalog.Discount.Repository;
using Katalog.Shared.Dtos;

namespace Katalog.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ResponseDto> Create(Entities.Discount discount)
        {
            var result = await _discountRepository.Create(discount);
            if (result)
                return ResponseDto.Success(204);
            return ResponseDto.Fail("An error occurred while creating the discount.", 500);
        }

        public async Task<ResponseDto<IEnumerable<Entities.Discount>>> GetAll()
        {
            var result = await _discountRepository.GetAll();
            return ResponseDto<IEnumerable<Entities.Discount>>.Success(result, 200);
        }

        public async Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByCategoryIds(string[] categoryIds)
        {
            var result = await _discountRepository.GetAll(); //TODO: IT'S GOING TO BE SET.
            return ResponseDto<IEnumerable<Entities.Discount>>.Success(result, 200);
        }

        public async Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByCode(string code)
        {
            var result = await _discountRepository.GetByCode(code);
            return ResponseDto<IEnumerable<Entities.Discount>>.Success(result, 200);
        }

        public async Task<ResponseDto<Entities.Discount>> GetById(int id)
        {
            var result = await _discountRepository.GetById(id);
            return ResponseDto<Entities.Discount>.Success(result, 200);
        }

        public async Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByProductIds(string[] productIds)
        {
            var result = await _discountRepository.GetAll();//TODO: IT'S GOING TO BE SET.
            return ResponseDto<IEnumerable<Entities.Discount>>.Fail("This method cannot be used", 500);

        }

        public async Task<ResponseDto<IEnumerable<Entities.Discount>>> GetByStoreIds(string[] storeIds)
        {
            var result = await _discountRepository.GetAll();//TODO: IT'S GOING TO BE SET.
            return ResponseDto<IEnumerable<Entities.Discount>>.Fail("This method cannot be used", 500);

        }

        public async Task<ResponseDto<Entities.Discount>> GetByUserIdAndCode(string code, string userId)
        {
            var result = await _discountRepository.GetByUserIdAndCode(code, userId);
            if (result == null)
                return ResponseDto<Entities.Discount>.Fail("The code you are searching is invalid.", 404);
            return ResponseDto<Entities.Discount>.Success(result, 200);
        }

        public async Task<ResponseDto> Remove(int id)
        {
            var resultSuccess = await _discountRepository.Delete(id);
            if (resultSuccess)
                return ResponseDto.Fail("The code you are trying to remove is invalid.", 404);
            return ResponseDto.Success(204);

        }

        public async Task<ResponseDto> Update(Entities.Discount discount)
        {
            var resultSuccess = await _discountRepository.Update(discount);
            if (resultSuccess)
                return ResponseDto.Success(204);
            return ResponseDto.Fail("An error occurred - please try again after a while", 500);


        }

        public async Task<ResponseDto> UseCode(string code)
        {
            var discount = await _discountRepository.GetByCode(code);
            //TODO:USECODE IS GONNA BE implemented.
            return null;

        }
        public Entities.Discount CheckTheCodeIsLimited(Entities.Discount discount)
        {
            if (discount.IsLimited && discount.Amount > 0)
            {
                discount.Amount--;
            }
            else
                throw new Exception("This code cannot be used.");
            return discount;




        }

    }
}
