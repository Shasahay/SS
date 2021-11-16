using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Request;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IBasketProvider _basketProvider;
        public BasketService(IMapper mapper, IBasketProvider basketProvider): base(mapper)
        {
            this._basketProvider = basketProvider;
        }
        public async Task<bool> AddBasket(BasketRequest basketRequest, CancellationToken cancellationToken)
        {
            var bItems = this._mapper.Map<IEnumerable<BasketItemRequest>, IEnumerable<BasketItem>>(basketRequest.Items);
            return await this._basketProvider.AddBasket(basketRequest.BasketId.GetValueOrDefault(), basketRequest.BasketUId, basketRequest.DeliveryMethodId.GetValueOrDefault(), basketRequest.ClientSecret, basketRequest.PaymentIntendId, basketRequest.ShippingPrice.GetValueOrDefault(), bItems, "Test", cancellationToken);
        }

        public async Task<BasketResponse> AddOrUpdateBasket(BasketRequest basketRequest, CancellationToken cancellationToken)
        {
            var bItems = this._mapper.Map<IEnumerable<BasketItemRequest>, IEnumerable<BasketItem>>(basketRequest.Items);
            var basket = await this._basketProvider.AddOrUpdateBasket(basketRequest.BasketId.GetValueOrDefault(), basketRequest.BasketUId, basketRequest.DeliveryMethodId.GetValueOrDefault(), basketRequest.ClientSecret, basketRequest.PaymentIntendId, basketRequest.ShippingPrice.GetValueOrDefault(), bItems, "Test", cancellationToken);
            
            //var basketItem = basket.Select
            var basketResponse = this._mapper.Map<BasketView, BasketResponse>(basket.FirstOrDefault());
            var basketItem = this._mapper.Map<IEnumerable<BasketView>, IEnumerable<BasketItemResponse>>(basket);
            basketResponse.Items = basketItem;
            return basketResponse;
        }

        public async Task<bool> DeleteBasket(string basketUId, CancellationToken cancellationToken)
            => await this._basketProvider.DeleteBasket(basketUId, cancellationToken);

        public async Task<BasketResponse> GetBasket(string basketUId, CancellationToken cancellationToken)
        {
            var basket = await this._basketProvider.GetBasket(basketUId, cancellationToken);
            BasketResponse response;

            if (basket != null)
            {
                var basketItems = await this._basketProvider.GetBasketItems(basketUId, cancellationToken);
                response = new BasketResponse() {
                    BasketId = basket.BasketId,
                    BasketUId = basket.BasketUId,
                    DeliveryMethodId = basket.DeliveryMethodId,
                    ClientSecret = basket.ClientSecret,
                    PaymentIntendId = basket.PaymentIntendId,
                    ShippingPrice = basket.ShippingPrice,
                    Items = basketItems != null ? this._mapper.Map<IEnumerable<BasketItem>, IEnumerable<BasketItemResponse>>(basketItems) : null
                };
                return response;
            }
            return null;
        }
    }
}
