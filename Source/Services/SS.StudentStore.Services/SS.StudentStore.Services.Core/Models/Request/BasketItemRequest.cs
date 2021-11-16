using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Request
{
    public class BasketItemRequest
    {
        
        public long? BasketItemId { get; set; }
        public long? BasketId { get; set; }
        [Required]
        public long ProductId { get; set; }
        
        public string ProductName { get; set; }

        public int ProductTypeId { get; set; }
        //[Required]
        //[Range(10, double.MaxValue, ErrorMessage = "Price must be greater than 10")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be atleast 1")]
        public int Quantity { get; set; }
        //[Required]
        public string PictureUrl { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
