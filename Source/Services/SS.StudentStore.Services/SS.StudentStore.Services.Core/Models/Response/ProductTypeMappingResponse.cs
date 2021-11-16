using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class ProductTypeMappingResponse
    {
        public long ProductTypeMappingId { get; set; }
        public int ProductTypeId { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
