using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Identity
{
    public class AddOrUpdateAddressCommand : IRequest<AddressResponse>
    {
        public AddressRequest addressRequest { get; set; }
        public string UserEmail { get; set; }
    }


    public class AddOrUpdateAddressCommandHandler : IRequestHandler<AddOrUpdateAddressCommand, AddressResponse>
    {
        private readonly IAccountService _accounService;
        public AddOrUpdateAddressCommandHandler(IAccountService accountService)
            => this._accounService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        public async Task<AddressResponse> Handle(AddOrUpdateAddressCommand request, CancellationToken cancellationToken)
        { 
            if(!string.IsNullOrEmpty(request.UserEmail))
            {
                var user = await this._accounService.GetUser(request.UserEmail, cancellationToken);
                request.addressRequest.UserId = user.UserId;
            }
           return await this._accounService.AddOrUpdateAddress(request.addressRequest, cancellationToken);
        }
    }
}
