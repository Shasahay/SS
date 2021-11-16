using MediatR;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Features.Identity
{
    public class GetAddressByEmailQuery : IRequest<AddressResponse>
    {
        public string UserEmail { get; set; }
    }

    public class GetAddressByEmailQueryHandler : IRequestHandler<GetAddressByEmailQuery, AddressResponse>
    {
        private readonly IAccountService _accountService;
        public GetAddressByEmailQueryHandler(IAccountService accountService)
            => this._accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        public async Task<AddressResponse> Handle(GetAddressByEmailQuery request, CancellationToken cancellationToken)
            => await this._accountService.GetAddress(request.UserEmail, cancellationToken);
    }
}
