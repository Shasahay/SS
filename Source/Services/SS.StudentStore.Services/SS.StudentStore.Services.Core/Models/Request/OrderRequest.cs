using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Request
{
    public class OrderRequest
    {
        public long BasketId { get; set; }
        public string BasketUId { get; set; }
        public int DeliveryMethodId { get; set; }
        public long AddressId { get; set; }
        public AddressRequest AddressRequest { get; set; }
    }
}
