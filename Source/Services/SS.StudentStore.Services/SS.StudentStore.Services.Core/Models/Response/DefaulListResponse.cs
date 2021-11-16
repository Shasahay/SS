using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class DefaulListResponse<T>
    {
        public List<T> Data { get; set; }
        public long TotalCount { get; set; }
    }
}
