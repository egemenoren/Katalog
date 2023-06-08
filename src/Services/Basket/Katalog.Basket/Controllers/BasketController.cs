using Katalog.Basket.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Katalog.Basket.Controllers
{
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet("GetUsersBasket")]
        [ProducesResponseType(typeof(Entities.Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Basket>> GetUsersBasket(string userId)
        {
            return Ok(await _basketRepository.GetBasket(userId));
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
        public async Task<ActionResult> RemoveBasket(string userId)
        {
            await _basketRepository.DeleteBasket(userId);
            return Ok();
        }
    }
}
