using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class BasketItemResponse
    {
        public long? BasketItemId { get; set; }
        public long? BasketId { get; set; }
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
