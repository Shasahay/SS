using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Services
{
    public interface IBasketService
    {
        //Task<bool> AddBasket(BasketRequest basket, IEnumerable<BasketItemRequest> basketItems, string user, CancellationToken cancellationToken);

        Task<bool> AddBasket(BasketRequest basketRequest, CancellationToken cancellationToken);
        Task<BasketResponse> AddOrUpdateBasket(BasketRequest basketRequest, CancellationToken cancellationToken);
        Task<BasketResponse> GetBasket(string basketUId, CancellationToken cancellationToken);
        Task<bool> DeleteBasket(string basketUId, CancellationToken cancellationToken);
    }
}
