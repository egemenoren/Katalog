using Katalog.Discount.Entities;
using Katalog.Discount.Services;
using Katalog.Shared.Dtos;
using Katalog.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;
        public DiscountController(IDiscountService discountService,ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _discountService.GetAll();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetById(id);
            return Ok(result);
        }
        [HttpGet("getbycode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _discountService.GetByCode(code);
            return Ok(result);

        }
        [HttpGet("getbyusercode")]
        public async Task<IActionResult> GetByUserIdAndCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            var result = await _discountService.GetByUserIdAndCode(code,userId);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Entities.Discount discount)
        {
            discount.CreatedById = _sharedIdentityService.GetUserId;
            var result = await _discountService.Create(discount);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Entities.Discount discount)
        {
            var result = await _discountService.Update(discount);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _discountService.Remove(id);
            return Ok(result);
        }




    }
}
