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
    public class AddOrUpdatePaymentIntentCommand : IRequest<BasketResponse>
    {
        public string BasketUId { get; set; }
        public string UserEmail { get; set; }
    }

    public class AddOrUpdatePaymentIntentCommandHandler : IRequestHandler<AddOrUpdatePaymentIntentCommand, BasketResponse>
    {
        private readonly IPaymentService _paymentService;

        public AddOrUpdatePaymentIntentCommandHandler(IPaymentService paymentService)
            => this._paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        public async Task<BasketResponse> Handle(AddOrUpdatePaymentIntentCommand request, CancellationToken cancellationToken)
            => await this._paymentService.AddOrUpdatePaymentIntent(request.BasketUId, request.UserEmail, cancellationToken);
    }

}
