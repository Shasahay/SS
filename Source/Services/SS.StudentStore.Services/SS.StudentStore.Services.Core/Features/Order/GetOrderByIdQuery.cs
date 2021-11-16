using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Order
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public long OrderId { get; set; }
    }

    public class GetOrderBYIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IOrderService _orderService;
        public GetOrderBYIdQueryHandler(IOrderService orderService)
            => this._orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
           => await this._orderService.GetOrder(request.OrderId, cancellationToken);
    }
}
