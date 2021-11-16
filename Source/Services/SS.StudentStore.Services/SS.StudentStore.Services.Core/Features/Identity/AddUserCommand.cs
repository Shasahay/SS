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
    public class AddUserCommand : IRequest<UserResponse>
    {
        public CreateUserRequest CreateUser { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserResponse>
    {
        private readonly IAccountService _accountService;

        public AddUserCommandHandler(IAccountService accountService)
            => this._accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        public async Task<UserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
            => await this._accountService.AddUser(request.CreateUser, cancellationToken);
        
    }
}
