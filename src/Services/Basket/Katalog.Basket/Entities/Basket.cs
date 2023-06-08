namespace Katalog.Basket.Entities
{
    public class Basket
    {
        public string userId { get; set; }
        public List<BasketItem> items { get; set; }
        public decimal priceTotal
        {
            get
            {
                decimal price = 0;
                foreach (var item in items)
                {
                    price += item.price * item.quantity;
                }
                return price;
            }
        }
    }
}
