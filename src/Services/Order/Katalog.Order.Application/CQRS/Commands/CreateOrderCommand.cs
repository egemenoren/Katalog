using Katalog.Order.Application.Dtos;
using Katalog.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.CQRS.Commands
{
    public class CreateOrderCommand:IRequest<ResponseDto<OrderCreatedResponseDto>>
    {
        public string CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
