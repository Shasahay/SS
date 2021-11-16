using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class OrderView
    {
        [Key]
        public long OrderId { get; set; }
        public string UserEmail { get; set; }
        public long AddressId { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }
        public string PaymentIntentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public long OrderItemId { get; set; }
        public long ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductTypeName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int NumberOfMonths { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderItemCreatedDate { get; set; }

    }
}
