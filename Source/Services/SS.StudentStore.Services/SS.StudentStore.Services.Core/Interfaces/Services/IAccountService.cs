using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<UserResponse> AddUser(CreateUserRequest createUser, CancellationToken cancellationToken);
        Task<AddressResponse> AddOrUpdateAddress(AddressRequest addressRequest, CancellationToken cancellationToken);
        Task<UserResponse> AuthenticateUser(LoginRequest loginRequest, CancellationToken cancellationToken);
        Task<bool> IsEmailExist(string email, CancellationToken cancellationToken);
        Task<UserResponse> GetUser(string email, CancellationToken cancellationToken);
        Task<UserResponse> GetUserByUserName(string email, CancellationToken cancellationToken);
        Task<UserResponse> GetUser(int userId, CancellationToken cancellationToken);
        Task<AddressResponse> GetAddress(string email, CancellationToken cancellationToken);
        Task<AddressResponse> GetAddress(int userId, CancellationToken cancellationToken);

    }
}
