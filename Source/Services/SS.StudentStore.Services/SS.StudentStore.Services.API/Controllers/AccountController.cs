using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.StudentStore.Services.Core.Features.Identity;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
            =>  this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new AddUserCommand() { CreateUser = createUserRequest }, cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("currentuser")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var result = await this._mediator.Send(new GetUserByEmailQuery() { Email = userEmail }, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetUserByEmail/{email}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(string email, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new GetUserByEmailQuery() { Email = email }, cancellationToken);
            return Ok(result);
        }

        [HttpGet("IsEmailExist/{email}")]
        public async Task<IActionResult> IsEmailExist(string email, CancellationToken cancellationToken)
        {
            var user = await this.GetUser(email, cancellationToken);
            if(((ObjectResult)user).Value != null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
        {
           var result = await this._mediator.Send(new GetUserLoginQuery() { LoginRequest = loginRequest }, cancellationToken);
            return this.Ok(result);
        }
        [Authorize]
        [HttpPost("addorupdate-address")]
        public async Task<IActionResult> AddOrUpdateAddress([FromBody] AddressRequest addressRequest, CancellationToken cancellationToken)
        {
            var userEmail = string.Empty;
            if(!addressRequest.UserId.HasValue)
            {
                userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            }
            var result = await this._mediator.Send(new AddOrUpdateAddressCommand() { addressRequest = addressRequest, UserEmail = userEmail }, cancellationToken);
            return this.Ok(result);
        }

        [Authorize]
        [HttpGet("address")]
        //[Route("address")]
        public async Task<IActionResult> GetUserAddress(CancellationToken cancellationToken)
        {   
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var address = await this._mediator.Send(new GetAddressByEmailQuery() { UserEmail = userEmail }, cancellationToken);   //await this.GetAddress(userEmail, cancellationToken);
            return Ok(address);
        }

        [HttpGet("get-adddress")]
        public async Task<IActionResult> GetAddress(string email, CancellationToken cancellationToken)
        {
           var address = await this._mediator.Send(new GetAddressByEmailQuery() { UserEmail = email }, cancellationToken);
            return this.Ok(address);
        }    
        
        


    }
}
