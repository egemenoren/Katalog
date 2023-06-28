using Katalog.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string CustomerId { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> Items => _orderItems;
        public Order(string customerId, Address address, DateTime updatedDate)
        {
            CustomerId = customerId;
            Address = address;
            CreatedDate = DateTime.Now;
            UpdatedDate = updatedDate;
            _orderItems = new List<OrderItem>();
        }
        public void AddOrderItem(string productId, string productName, decimal price, string photoUrl, int quantity)
        {
            var checkExists = _orderItems.Any(x => x.ProductId == productId);
            if (!checkExists)
            {
                var orderItem = new OrderItem(productId, productName, photoUrl, quantity, price);
                _orderItems.Add(orderItem);
            }
        }
        public decimal GetTotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in _orderItems)
                {
                    totalPrice += item.Quantity * item.Price;
                }
                return totalPrice;
            }
        }
    }
}
