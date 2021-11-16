using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IAddressProvider
    {
        Task<Address> AddAddress(Address address, CancellationToken cancellationToken);
        Task<IEnumerable<Address>> GetAllAddress(string email, CancellationToken cancellationToken);
        Task<Address> GetAddress(string email, CancellationToken cancellationToken);
        Task<Address> GetAddress(int userId, CancellationToken cancellationToken);
        Task<Address> GetAddressByUserName(string userName, CancellationToken cancellationToken);
    }
}
