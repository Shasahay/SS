using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethods(CancellationToken cancellationToken);
        Task<OrderResponse> CreateOrder(OrderRequest orderRequest, string userEmail, CancellationToken cancellationToken);
        Task<IEnumerable<OrderResponse>> GetOrder(string userEmail, CancellationToken cancellationToken);
        Task<OrderResponse> GetOrder(long orderId, CancellationToken cancellationToken);
    }
}
