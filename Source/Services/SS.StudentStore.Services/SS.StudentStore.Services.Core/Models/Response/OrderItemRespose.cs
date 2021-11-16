using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class OrderItemResponse
    {
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductTypeName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int NumberOfMonths { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
