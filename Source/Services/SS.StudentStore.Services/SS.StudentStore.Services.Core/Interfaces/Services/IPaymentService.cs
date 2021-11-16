using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<BasketResponse> AddOrUpdatePaymentIntent(string basketUId, string userEmail, CancellationToken cancellationToken);
    }
}
