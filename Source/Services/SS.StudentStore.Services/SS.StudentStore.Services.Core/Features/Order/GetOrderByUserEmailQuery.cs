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
    public class GetOrderByUserEmailQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserEmail { get; set; }
    }

    public class GetOrderByUserEmailQueryHandler : IRequestHandler<GetOrderByUserEmailQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderService _orderService;
        public GetOrderByUserEmailQueryHandler(IOrderService orderService)
            => this._orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserEmailQuery request, CancellationToken cancellationToken)
            => await this._orderService.GetOrder(request.UserEmail, cancellationToken);
    }
}
