using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IUserProvider
    {
        Task<UserView> AuthenticateUser(string email, string password, CancellationToken cancellationToken);
        Task<UserView> GetUser(int id, CancellationToken cancellationToken);
        Task<UserView> GetUserByUserName(string userName, CancellationToken cancellationToken);
        Task<UserView> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<UserView> AddUser(Users user, CancellationToken cancellationToken);
        Task<UserView> UpdateUser(Users user, CancellationToken cancellationToken);
    }
}
