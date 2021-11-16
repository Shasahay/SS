using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public interface IListWithCount<T>
    {
        IEnumerable<T> Data { get; set; }
        long TotalCount { get; set; }
    }
}
