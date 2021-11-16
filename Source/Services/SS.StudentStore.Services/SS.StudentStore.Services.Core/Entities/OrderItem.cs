using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class OrderItem
    {
        [Key]
        public long? OrderItemId { get; set; }
        public long? OrderId { get; set; }
        public long ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
