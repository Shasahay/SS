using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IUserProvider _userProvider;
        private readonly IAddressProvider _addressProvider;
        private readonly ITokenService _tokenService;
        public AccountService(IMapper mapper, IUserProvider userProvider, IAddressProvider addressProvider, ITokenService tokenService) : base(mapper)
        {
            this._userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            this._addressProvider = addressProvider ?? throw new ArgumentNullException(nameof(addressProvider));
            this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        public async Task<UserResponse> AuthenticateUser(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var user = await this._userProvider.AuthenticateUser(loginRequest.Email, loginRequest.Password, cancellationToken);
            
            if(user != null)
            {
                var response = this._mapper.Map<UserView, UserResponse>(user);
                response.Token = this._tokenService.CreateToken(user);
                return response;
            }
            return null;
        }
        public async Task<UserResponse> AddUser(CreateUserRequest createUser, CancellationToken cancellationToken)
        {
            var user = this._mapper.Map<CreateUserRequest, Users>(createUser);
            user.PasswordHash = user.ClearPassword; // pash hash logic
            var newUser = await this._userProvider.AddUser(user, cancellationToken);
            var result = this._mapper.Map<UserView, UserResponse>(newUser);
            result.Token = _tokenService.CreateToken(newUser);
            return result;
        }
       
        public async Task<UserResponse> GetUser(string email, CancellationToken cancellationToken)
        {
            var result = await this._userProvider.GetUserByEmail(email, cancellationToken);
            if (result != null)
            {
                var response = _mapper.Map<UserView, UserResponse>(result);
                response.Token = _tokenService.CreateToken(result);
                return response;
            }
            return null;
        }

        public async Task<UserResponse> GetUser(int userId, CancellationToken cancellationToken)
        {
            var result = await this._userProvider.GetUser(userId, cancellationToken);
            var response = _mapper.Map<UserView, UserResponse>(result);
            response.Token = _tokenService.CreateToken(result);
            return response;
        }

        public async Task<UserResponse> GetUserByUserName(string userName, CancellationToken cancellationToken)
        {
            var result = await this._userProvider.GetUserByUserName(userName, cancellationToken);
            var response = _mapper.Map<UserView, UserResponse>(result);
            response.Token = _tokenService.CreateToken(result);
            return response;
        }

        public async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
        {
            var result = await this._userProvider.GetUserByEmail(email, cancellationToken);
            if (result == null)
                return false;
            return true;
            
        }

        public async Task<AddressResponse> AddOrUpdateAddress(AddressRequest addressRequest, CancellationToken cancellationToken)
        {
            var address = this._mapper.Map<AddressRequest, Address>(addressRequest);
            var response = await this._addressProvider.AddAddress(address, cancellationToken);
            var result = this._mapper.Map<Address, AddressResponse>(response);
            return result;
        }

        public async Task<AddressResponse> GetAddress(string email, CancellationToken cancellationToken)
        {
            var result = await this._addressProvider.GetAddress(email, cancellationToken);
            var address = this._mapper.Map<Address, AddressResponse>(result);
            return address;
        }

        public async Task<AddressResponse> GetAddress(int userId, CancellationToken cancellationToken)
        {
            var result = await this._addressProvider.GetAddress(userId, cancellationToken);
            var address = this._mapper.Map<Address, AddressResponse>(result);
            return address;
        }

    }
}
