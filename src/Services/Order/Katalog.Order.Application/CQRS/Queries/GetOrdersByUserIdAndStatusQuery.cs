using Katalog.Order.Application.Dtos;
using Katalog.Order.Domain.OrderAggregate;
using Katalog.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.CQRS.Queries
{
    public class GetOrdersByUserIdAndStatusQuery : IRequest<ResponseDto<List<OrderDto>>>
    {
        public string CustomerId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
