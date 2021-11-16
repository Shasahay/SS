using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IOrderProvider
    {
        Task<Order> AddOrder(Order order, CancellationToken cancellationToken);
        Task<OrderView> CreateOrder(Order order, CancellationToken cancellationToken);
        Task<IEnumerable<OrderView>> CreateOrder(Order order, IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken);
        Task<IEnumerable<OrderView>> GetOrder(string userEmail, CancellationToken cancellationToken);
        Task<IEnumerable<OrderView>> GetOrder(long orderId, CancellationToken cancellationToken);
    }
}
