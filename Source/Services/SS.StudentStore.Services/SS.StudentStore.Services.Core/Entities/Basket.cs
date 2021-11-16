using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class Basket
    {
        [Key]
        public long BasketId { get; set; }
        public string BasketUId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntendId { get; set; }
        public decimal? ShippingPrice { get; set; }
    }
}
