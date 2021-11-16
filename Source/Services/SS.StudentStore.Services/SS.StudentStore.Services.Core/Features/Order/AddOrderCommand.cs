using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Order
{
    public class AddOrderCommand : IRequest<OrderResponse>
    {
        public OrderRequest OrderRequest { get; set; }
        public string UserEmail { get; set; }
    }

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderResponse>
    {
        private readonly IOrderService _orderService;

        public AddOrderCommandHandler(IOrderService orderService)
            => this._orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        public async Task<OrderResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
            => await this._orderService.CreateOrder(request.OrderRequest, request.UserEmail, cancellationToken);
    }
}
