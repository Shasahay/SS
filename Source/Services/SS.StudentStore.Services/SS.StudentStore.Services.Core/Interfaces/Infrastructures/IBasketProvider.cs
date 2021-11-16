using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Interfaces.Infrastructures
{
    public interface IBasketProvider
    {
        Task<Basket> GetBasket(string basketUId, CancellationToken cancellationToken);
        Task<Basket> GetBasket(long basketId, CancellationToken cancellationToken);
        Task<IEnumerable<BasketView>> GetBasketView(string basketUId, CancellationToken cancellationToken);
        Task<IEnumerable<BasketItem>> GetBasketItems(string basketUId, CancellationToken cancellationToken);
        Task<bool> AddBasket(Basket basket, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken);
        Task<bool> AddBasket(long basketId, string basketUId, int deliveryMethodId, string clientSecret, string paymentIntendId, decimal shippingPrice, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken);
        Task<IEnumerable<BasketView>> AddOrUpdateBasket(long basketId, string basketUId, int deliveryMethodId, string clientSecret, string paymentIntendId, decimal shippingPrice, IEnumerable<BasketItem> basketItems, string user, CancellationToken cancellationToken);
        Task<Basket> UpdateBasket(string basketUId, CancellationToken cancellationToken);
        Task<bool> DeleteBasket(string basketUId, CancellationToken cancellationToken);
    }
}
