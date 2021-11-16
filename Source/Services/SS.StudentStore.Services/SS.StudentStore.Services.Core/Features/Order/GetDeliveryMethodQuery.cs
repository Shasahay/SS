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
    public class GetDeliveryMethodQuery : IRequest<IEnumerable<DeliveryMethodResponse>>
    {
    }

    public class GetDeliveryMethodQueryHandler : IRequestHandler<GetDeliveryMethodQuery, IEnumerable<DeliveryMethodResponse>>
    {
        private readonly IOrderService _orderService;
        public GetDeliveryMethodQueryHandler(IOrderService _orderService)
            => this._orderService = _orderService ?? throw new ArgumentNullException(nameof(_orderService));
        public async Task<IEnumerable<DeliveryMethodResponse>> Handle(GetDeliveryMethodQuery request, CancellationToken cancellationToken)
            => await this._orderService.GetDeliveryMethods(cancellationToken);
    }
}
