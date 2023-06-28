using Katalog.Order.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.CQRS.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<Shared.Dtos.ResponseDto<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
