using SS.StudentStore.Services.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class Order
    {
        [Key]
        public long? OrderId { get; set; }
        public string UserEmail { get; set; }
        public long? UserId { get; set; }
        public long AddressId { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }
        public string PaymentIntentId { get; set; }
        public int DeliveryMethodId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
