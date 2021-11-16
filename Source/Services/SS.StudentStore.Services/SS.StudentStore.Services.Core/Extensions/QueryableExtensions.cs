using SS.StudentStore.Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SS.StudentStore.Services.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageSize, int pageNumber)
        {
            if(pageSize == 0)
            {
                return query;
            }

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string field, string direction = "OrderBy")
        {
            if ( string.IsNullOrEmpty(field))
            {
                return query;
            }

            var type = typeof(T);
            var property = type.GetProperty(field);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            string methodName = direction;
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, query.Expression, Expression.Quote(orderByExp));
            return query.Provider.CreateQuery<T>(resultExp);


            //ParameterExpression parameter = Expression.Parameter(query.ElementType, "P");

            //MemberExpression property = Expression.Property(parameter, field);
            //LambdaExpression lambda = Expression.Lambda(property, parameter);

            //string methodName = direction;

            //Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
            //                      new Type[] { query.ElementType, property.Type },
            //                      query.Expression, Expression.Quote(lambda));

            //return query.Provider.CreateQuery<T>(methodCallExpression);



        }

        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> stringProperty, string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            // The below represents the following lamda:
            // source.Where(x => x.[property] != null
            //                && x.[property].Contains(searchTerm))

            //Create expression to represent x.[property] != null
            var isNotNullExpression = Expression.NotEqual(stringProperty.Body,
                                                          Expression.Constant(null));

            //Create expression to represent x.[property].Contains(searchTerm)
            var searchTermExpression = Expression.Constant(searchTerm);
            var checkContainsExpression = Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);

            //Join not null and contains expressions
            var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);

            var methodCallExpression = Expression.Call(typeof(Queryable),
                                                       "Where",
                                                       new Type[] { source.ElementType },
                                                       source.Expression,
                                                       Expression.Lambda<Func<T, bool>>(notNullAndContainsExpression, stringProperty.Parameters));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }

    }
}
