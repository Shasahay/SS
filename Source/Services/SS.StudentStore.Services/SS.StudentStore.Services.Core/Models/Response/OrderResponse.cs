using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class OrderResponse
    {
        public long OrderId { get; set; }
        public string UserEmail { get; set; }
        public long AddressId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        //public string PaymentIntentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<OrderItemResponse> OrderItems { get; set; }
    }
}
