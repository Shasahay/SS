using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Basket
{
    public class GetBasketByUIdQuery : IRequest<BasketResponse>
    {
        public string BasketUID { get; set; }
    }

    public class GetBasketByUIdQueryHandler : IRequestHandler<GetBasketByUIdQuery, BasketResponse>
    {
        private IBasketService _service;

        public GetBasketByUIdQueryHandler(IBasketService basketService)
         => this._service = basketService ?? throw new ArgumentNullException(nameof(basketService));
        public async Task<BasketResponse> Handle(GetBasketByUIdQuery request, CancellationToken cancellationToken)
            => await _service.GetBasket(request.BasketUID, cancellationToken);
        
    }
}
