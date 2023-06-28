using Katalog.Order.Application.CQRS.Commands;
using Katalog.Order.Application.Dtos;
using Katalog.Order.Domain.OrderAggregate;
using Katalog.Order.Infrastructure;
using Katalog.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.CQRS.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDto<OrderCreatedResponseDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<OrderCreatedResponseDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var dtoAddress = request.Address;
            var address = new Address(dtoAddress.District, dtoAddress.City, dtoAddress.Street, dtoAddress.ZipCode, dtoAddress.Name, dtoAddress.Surname, dtoAddress.MobileNumber);
            var order = new Order.Domain.OrderAggregate.Order(request.CustomerId, address);
            request.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PhotoUrl, x.Quantity);
            });
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return ResponseDto<OrderCreatedResponseDto>.Success(new OrderCreatedResponseDto { Id = order.Id }, 200);
        }
    }
}
