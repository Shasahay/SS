using AutoMapper;
using SS.StudentStore.Services.Core.Entities;
using SS.StudentStore.Services.Core.Enums;
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
    public class OrderService : BaseService, IOrderService
    {
        private readonly IDeliveryMethodProvider _dmProvider;
        private readonly IBasketProvider _basketProvider;
        private readonly IOrderProvider _OrderProvider;
        private readonly IUserProvider _UserProvider;
        private readonly IAddressProvider _addressProvider;
        public OrderService(IMapper mapper, IDeliveryMethodProvider dmProvider, IBasketProvider basketProvider, IOrderProvider orderProvider, IUserProvider userProvider, IAddressProvider addressProvider) : base(mapper)
        {
            this._dmProvider = dmProvider ?? throw new ArgumentNullException(nameof(dmProvider));
            this._basketProvider = basketProvider ?? throw new ArgumentNullException(nameof(basketProvider));
            this._OrderProvider = orderProvider ?? throw new ArgumentNullException(nameof(orderProvider));
            this._UserProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            this._addressProvider = addressProvider ?? throw new ArgumentNullException(nameof(addressProvider));
        }

        public async Task<OrderResponse> CreateOrder(OrderRequest orderRequest, string userEmail, CancellationToken cancellationToken)
        {
            var user = await this._UserProvider.GetUserByEmail(userEmail, cancellationToken);
            long? addressId = 0L;
            if(orderRequest.AddressRequest != null)
            {
                var add = this._mapper.Map<AddressRequest, Address>(orderRequest.AddressRequest);
                var updateAddress = await this._addressProvider.AddAddress(add, cancellationToken);
                addressId = updateAddress.AddressId;
            }
                      
            var basketView = await this._basketProvider.GetBasketView(orderRequest.BasketUId, cancellationToken);
            var subtotal = basketView.FirstOrDefault().ShippingPrice.Value;
            var order = new Order() {
                AddressId =  addressId.GetValueOrDefault(0) == 0 ? orderRequest.AddressId : addressId.Value,
                UserId = user.UserId,
                UserEmail = userEmail,
                SubTotal = subtotal + basketView.Sum(x=> x.Price * x.Quantity),
                Status = OrderStatus.Pending.ToString(),
                DeliveryMethodId = basketView.FirstOrDefault().DeliveryMethodId.Value,
                PaymentIntentId = basketView.FirstOrDefault().PaymentIntendId,
                CreatedBy = userEmail,
                CreatedDate = DateTime.Now
            };
            var basketitem = this._mapper.Map<IEnumerable<BasketView>, IEnumerable<BasketItem>>(basketView);
            var orderItem = this._mapper.Map<IEnumerable<BasketItem>, IEnumerable<OrderItem>>(basketitem);
            var orderResult = await this._OrderProvider.CreateOrder(order, orderItem, cancellationToken);
            //var orderRes = new OrderResponse();
            var orderResponse = this._mapper.Map<OrderView, OrderResponse>(orderResult.FirstOrDefault());
            orderResponse.Total = orderResponse.SubTotal + basketView.FirstOrDefault().ShippingPrice.Value;
            var orderResItem = this._mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderItemResponse>>(orderResult);
            orderResponse.OrderItems = orderResItem;
            return orderResponse;
        }


        public async Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethods(CancellationToken cancellationToken)
        {
            var deliveryMethod = await this._dmProvider.GetDeliveryMethods(cancellationToken);
            var response = this._mapper.Map<IEnumerable<DeliveryMethod>, IEnumerable<DeliveryMethodResponse>>(deliveryMethod);
            return response;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrder(string userEmail, CancellationToken cancellationToken)
        {
            var allOrders = await this._OrderProvider.GetOrder(userEmail, cancellationToken);
            //Getting the distinct order Id
            var orders =  allOrders.GroupBy(order => order.OrderId).Select(group => group.First());
            var orderResponses = new List<OrderResponse>();

            foreach (var order in orders)
            {
                var orderRes = this._mapper.Map<OrderView, OrderResponse>(order);
                // preparing order items for each order
                var allOrder = allOrders.Where(x => x.OrderId == order.OrderId);
                //get the shipping price
                var orderResItem = this._mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderItemResponse>>(allOrder);
                orderRes.OrderItems = orderResItem;
                orderResponses.Add(orderRes);
            }
            return orderResponses;
             
        }

        public async Task<OrderResponse> GetOrder(long orderId, CancellationToken cancellationToken)
        {
            var order = await this._OrderProvider.GetOrder(orderId, cancellationToken);
            var orderResponse = this._mapper.Map<OrderView, OrderResponse>(order.FirstOrDefault());
            var orderResItem = this._mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderItemResponse>>(order);
            orderResponse.OrderItems = orderResItem;
            return orderResponse;
        }
    }
}
