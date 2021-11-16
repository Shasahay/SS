using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class BasketResponse
    {
        public long BasketId { get; set; }
        public string  BasketUId { get; set; }
        public IEnumerable<BasketItemResponse> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntendId { get; set; }
        public decimal? ShippingPrice { get; set; }

    }
}
