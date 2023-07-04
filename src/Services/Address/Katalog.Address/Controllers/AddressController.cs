using Katalog.Address.Dto;
using Katalog.Address.Repositories.Abstract;
using Katalog.Address;
using Katalog.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Katalog.Shared.Services;

namespace Katalog.Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ISharedIdentityService _sharedIdentityService;
        public AddressController(IAddressRepository addressRepository,ISharedIdentityService sharedIdentityService)
        {
            
            _addressRepository = addressRepository;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpPost("SaveAddress")]
        public async Task<IActionResult> SaveAddress([FromBody] Entities.Address address)
        {
            address.UserId = _sharedIdentityService.GetUserId;
            await _addressRepository.Create(address);
            return Ok(ResponseDto<Entities.Address>.Success(address, 200));
        }
        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress([FromBody] Entities.Address address)
        {
            address.UserId = _sharedIdentityService.GetUserId;
            var resultSuccess = await _addressRepository.Update(address);
            if (resultSuccess)
                return Ok(ResponseDto<Entities.Address>.Success(address, 200));
            return StatusCode(500, ResponseDto.Fail("An unexpected error.", 500));
        }
        [HttpDelete("RemoveAddress")]
        public async Task<IActionResult> RemoveAddress(string addressId)
        {
            var result = await _addressRepository.Delete(addressId);
            if(result)
                return Ok(ResponseDto.Success(200));
            return StatusCode(500, ResponseDto.Fail("Address cannot be removed.", 500));

        }
        [HttpGet("GetAllAdressesByUserId")]
        public async Task<IActionResult> GetAllByUserId()
        {
            var userId = _sharedIdentityService.GetUserId;
            var result = await _addressRepository.GetAddressesByUserId(userId);
            return Ok(ResponseDto<List<Entities.Address>>.Success(result,200));
        }

    }
}
