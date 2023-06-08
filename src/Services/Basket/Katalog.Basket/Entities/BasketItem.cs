namespace Katalog.Basket.Entities
{
    public class BasketItem
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
