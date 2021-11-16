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
    public class GetUserLoginQuery : IRequest<UserResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }

    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, UserResponse>
    {
        private readonly IAccountService _accountService;
        public GetUserLoginQueryHandler(IAccountService accountService)
            => this._accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        public async Task<UserResponse> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
            => await this._accountService.AuthenticateUser(request.LoginRequest, cancellationToken);
    }
}
