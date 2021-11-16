using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class SubCategoryResponse
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
