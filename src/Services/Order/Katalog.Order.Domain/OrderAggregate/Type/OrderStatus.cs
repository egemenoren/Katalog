using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Domain.OrderAggregate
{
    public enum OrderStatus:short
    {
        OrderPlaced =0,
        OrderConfirmed =1,
        OrderRejected =2,
        OrderCancelled =3,
        SellerCannotSupply =4,
        Shipped = 5,
        Delivered = 6,
        DeliveryRefusedByCustomer = 7,
        Returned = 8
    }
}
