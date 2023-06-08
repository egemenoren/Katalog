using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Katalog.Basket.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<Entities.Basket> AddFakeBasket(Entities.Basket basket)
        {
            return null;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisCache.RemoveAsync(userId);
        }

        public async Task<Entities.Basket> GetBasket(string userId)
        {
            var basket = await _redisCache.GetStringAsync(userId);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<Entities.Basket>(basket);
        }

        public async Task<Entities.Basket> UpdateBasket(Entities.Basket basket)
        {
            await _redisCache.SetStringAsync(basket.userId, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.userId);
        }
    }
}
