using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS.StudentStore.Services.Core.Features.Order;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
            => this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("delivery-method")]
        public async Task<IActionResult> GetDeliveryMethods(CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new GetDeliveryMethodQuery(), cancellationToken);
            return this.Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder(CancellationToken cancellationToken)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var response = await this._mediator.Send(new GetOrderByUserEmailQuery() { UserEmail = userEmail }, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(long id, CancellationToken cancellationToken)
        {
            var response = await this._mediator.Send(new GetOrderByIdQuery() { OrderId = id }, cancellationToken);
            return this.Ok(response);
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest, CancellationToken cancellationToken)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var result = await this._mediator.Send(new AddOrderCommand() { OrderRequest = orderRequest, UserEmail = userEmail }, cancellationToken);
            return this.Ok(result);
        }
    }
}
