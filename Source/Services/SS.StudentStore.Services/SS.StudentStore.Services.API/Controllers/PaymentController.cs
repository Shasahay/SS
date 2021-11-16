using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.StudentStore.Services.Core.Features.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
            => this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [Authorize]
        [HttpPost("{basketUId}")]
        public async Task<IActionResult> AddOrUpdatePaymentIntent(string basketUId, CancellationToken cancellationToken)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var result = await this._mediator.Send(new AddOrUpdatePaymentIntentCommand() { BasketUId = basketUId, UserEmail = userEmail }, cancellationToken);
            return this.Ok(result);
        }

    }
}
