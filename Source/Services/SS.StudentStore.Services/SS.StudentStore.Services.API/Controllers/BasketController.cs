using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.StudentStore.Services.Core.Features.Basket;
using SS.StudentStore.Services.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
            => this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        [Route("AddBasket")]
        public async Task<IActionResult> AddBasket([FromBody] BasketRequest basketRequest, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new AddBasketCommand() { BasketRequest = basketRequest }, cancellationToken);
            return Ok(result);
            
        }

        [HttpPost("GetBasket/{basketUId}")]
        public async Task<IActionResult> GetBasket(string basketUId, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new GetBasketByUIdQuery() { BasketUID = basketUId }, cancellationToken);
            return this.Ok(result);
        }

        [HttpPost]
        [Route("AddOrUpdateBasket")]
        public async Task<IActionResult> AddOrUpdateBasket([FromBody] BasketRequest basketRequest, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new UpdateBasketCommand() { BasketRequest = basketRequest }, cancellationToken);
            return Ok(result);

        }

        [HttpDelete("delete/{basketUId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket([FromRoute] string basketUId, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new DeleteBasketCommand() { BasketUId = basketUId }, cancellationToken);
            return Ok(result);

        }

    }
}
