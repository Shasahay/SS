using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Basket
{
    public class UpdateBasketCommand : IRequest<BasketResponse>
    {
        public BasketRequest BasketRequest { get; set; }
    }

    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, BasketResponse>
    {
        private readonly IBasketService _service;
        public UpdateBasketCommandHandler(IBasketService basketService)
        => this._service = basketService ?? throw new ArgumentNullException(nameof(basketService));
        public async Task<BasketResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            => await this._service.AddOrUpdateBasket(request.BasketRequest, cancellationToken);
    }
}
