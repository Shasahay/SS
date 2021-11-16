using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS.StudentStore.Services.API.Extensions
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
