using Katalog.Basket.Repository;
using Katalog.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Katalog.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ISharedIdentityService _sharedIdentityService;
        public BasketController(IBasketRepository basketRepository,ISharedIdentityService sharedIdentityService)
        {
            _basketRepository = basketRepository;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet("GetUsersBasket")]
        [ProducesResponseType(typeof(Entities.Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Basket>> GetUsersBasket()
        {
            return Ok(await _basketRepository.GetBasket(_sharedIdentityService.GetUserId));
        }
        [HttpPut("UpdateBasket")]
        public async Task<ActionResult<Entities.Basket>> UpdateBasket([FromBody] Entities.Basket basket)
        {
            var basketUpdated = await _basketRepository.UpdateBasket(basket);
            if(basketUpdated == null)
                return NotFound();
            return Ok(basket);
        }
        [HttpDelete("RemoveBasket")]
        [ProducesResponseType(typeof(Entities.Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> RemoveBasket()
        {
            await _basketRepository.DeleteBasket(_sharedIdentityService.GetUserId);
            return Ok();
        }
    }
}
