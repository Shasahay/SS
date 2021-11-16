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
    public class GetUserByEmailQuery : IRequest<UserResponse>
    {
        public string Email { get; set; }
    }

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IAccountService _accountService;

        public GetUserByEmailQueryHandler(IAccountService accountService)
            => this._accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            => await this._accountService.GetUser(request.Email, cancellationToken);
    }
}
