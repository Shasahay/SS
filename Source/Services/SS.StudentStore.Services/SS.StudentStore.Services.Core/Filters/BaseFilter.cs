using SS.StudentStore.Services.Core.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SS.StudentStore.Services.Core.Filters
{
    public class BaseFilter<TEntity> : IFilter<TEntity>
    {
        public BaseFilter(Expression<Func<TEntity, bool>> criteria) 
        {
            Criteria = criteria;
        }
        public Expression<Func<TEntity, bool>> Criteria { get; }

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
