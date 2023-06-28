﻿using Katalog.Order.Application.CQRS.Queries;
using Katalog.Order.Application.Dtos;
using Katalog.Order.Application.Mapping;
using Katalog.Order.Infrastructure;
using Katalog.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.CQRS.Handlers
{
    public class GetOrdersByUserIdAndStatusQueryHandler : IRequestHandler<GetOrdersByUserIdAndStatusQuery, ResponseDto<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;

        public GetOrdersByUserIdAndStatusQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdAndStatusQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Include(x => x.Address).ToListAsync();
            if (orders.Any())
                return ResponseDto<List<OrderDto>>.Success(new List<OrderDto>(), 200);
            var orderDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return ResponseDto<List<OrderDto>>.Success(orderDto, 200);
        }
    }
}
