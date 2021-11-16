using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class DeliveryMethod
    {
        public int DeliveryMethodId { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
    }
}
