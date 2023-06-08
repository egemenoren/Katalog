using Katalog.Basket.Entities;

namespace Katalog.Basket.Repository
{
    public interface IBasketRepository
    {
        Task<Entities.Basket> GetBasket(string userId);
        Task<Entities.Basket> UpdateBasket(Entities.Basket basket);
        Task DeleteBasket(string userId);
        Task<Entities.Basket> AddFakeBasket(Entities.Basket basket);
    }
}
