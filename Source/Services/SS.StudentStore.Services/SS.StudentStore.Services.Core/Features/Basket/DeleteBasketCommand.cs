using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Basket
{
    public class DeleteBasketCommand : IRequest<bool>
    {
        public string BasketUId { get; set; }
    }

    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketService _service;

        public DeleteBasketCommandHandler(IBasketService basketService)
            => this._service = basketService ?? throw new ArgumentNullException(nameof(basketService));

        public Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            => this._service.DeleteBasket(request.BasketUId, cancellationToken);
    }
}
