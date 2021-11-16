using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SS.StudentStore.Services.Core.Interfaces.Filters
{
    public interface IFilter<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
