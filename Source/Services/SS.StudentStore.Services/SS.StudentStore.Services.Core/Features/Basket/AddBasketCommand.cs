using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Basket
{
    public class AddBasketCommand : IRequest<bool>
    {
        public BasketRequest BasketRequest { get; set; }
    }

    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommand, bool>
    {
        private readonly IBasketService _service;

        public AddBasketCommandHandler(IBasketService basketService)
            => this._service = basketService ?? throw new ArgumentNullException(nameof(basketService));

        public async Task<bool> Handle(AddBasketCommand request, CancellationToken cancellationToken)
            =>  await this._service.AddBasket(request.BasketRequest, cancellationToken);
        
    } 
}
