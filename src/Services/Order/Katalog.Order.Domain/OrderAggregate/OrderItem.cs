using Katalog.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PhotoUrl { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }


        public OrderItem(string productId, string productName, string photoUrl, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PhotoUrl = photoUrl;
            Quantity = quantity;
            Price = price;
        }
        public void UpdateOrderItem(string productName, string photoUrl, int quantity, decimal price)
        {
            ProductName = productName;
            PhotoUrl = photoUrl;
            Quantity = quantity;
            Price = price;

        }
    }
}
