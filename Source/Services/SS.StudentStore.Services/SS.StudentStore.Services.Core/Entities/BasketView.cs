using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class BasketView
    {
        [Key]
        public long BasketId { get; set; }
        public string BasketUId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string clientSecret { get; set; }
        public string PaymentIntendId { get; set; }
        public decimal? ShippingPrice { get; set; }
        public long BasketItemId { get; set; }
        public long ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
