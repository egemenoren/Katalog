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
        public string CustomerId { get; private set; }
        public Address Address { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {

        }
        public Order(string customerId, Address address)
        {
            CustomerId = customerId;
            Address = address;
            CreatedDate = DateTime.Now;
            _orderItems = new List<OrderItem>();
        }
        public void UpdateOrderStatus(OrderStatus status)
        {
            this.OrderStatus = status;
        }
        public void AddOrderItem(string productId, string productName, decimal price, string photoUrl, int quantity)
        {
            var checkExists = _orderItems.Any(x => x.ProductId == productId);
            if (!checkExists)
            {
                var orderItem = new OrderItem(productId, productName, photoUrl, quantity, price);
                _orderItems.Add(orderItem);
                this.UpdatedDate = DateTime.Now;
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
