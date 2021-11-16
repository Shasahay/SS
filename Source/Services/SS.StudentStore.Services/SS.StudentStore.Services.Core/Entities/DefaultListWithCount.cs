using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Entities
{
    public class DefaultListWithCount<T> : IListWithCount<T> where T: class
    {
        public IEnumerable<T> Data { get; set; }
        public long TotalCount { get; set; }
    }
}
