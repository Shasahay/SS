using AutoMapper;
using SS.StudentStore.Services.Core.Interfaces.Infrastructures;
using SS.StudentStore.Services.Core.Interfaces.Services;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.Core.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IBasketProvider _basketProvider;
        private readonly IProductProvider _productProvider;
        private readonly IDeliveryMethodProvider _dmProvider;
        private readonly IBasketService _basketService;
        public PaymentService(IMapper mapper, IBasketProvider basketProvider, IDeliveryMethodProvider deliveryMethodProvider, IProductProvider productProvider, IBasketService basketService) : base(mapper)
        {
            this._basketProvider = basketProvider;
            this._productProvider = productProvider;
            this._basketService = basketService;
            this._dmProvider = deliveryMethodProvider;
        }
        public async Task<BasketResponse> AddOrUpdatePaymentIntent(string basketUId, string userEmail, CancellationToken cancellationToken)
        {
            var basket = await this._basketProvider.GetBasket(basketUId, cancellationToken);
            if (basket == null)
                return null;
            var shippingPrice = 0m;

            if(basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await this._dmProvider.GetDeliveryMethod(basket.DeliveryMethodId.Value, cancellationToken);
                shippingPrice = deliveryMethod.Price;
            }

            var basketItem = await this._basketProvider.GetBasketItems(basketUId, cancellationToken);

            foreach (var item in basketItem)
            {
                var productItem = await this._productProvider.GetProduct(item.ProductId, cancellationToken);
                if(item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            //var piService = new PaymentIntentService()
            // Create Payment Intent 

            var updateBasketView = await this._basketProvider.AddOrUpdateBasket(basket.BasketId, basket.BasketUId,
                basket.DeliveryMethodId.GetValueOrDefault(), basket.ClientSecret,
                basket.PaymentIntendId, shippingPrice, basketItem, userEmail, cancellationToken);


            var updateBasket = await this._basketService.GetBasket(basketUId, cancellationToken);
            return updateBasket;
            
        }
    }
}
