using Polkanalysis.Domain.Contracts.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Repository;

public static class QueryableExtensions
{
    /// <summary>
    /// Filters the elements of an IQueryable based on the specified NumberCriteria<TValue> object 
    /// and a selector expression, and returns the resulting queryable sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the IQueryable.</typeparam>
    /// <typeparam name="TValue">The type of value to compare.</typeparam>
    /// <param name="queryable">The IQueryable to filter.</param>
    /// <param name="criteria">The NumberCriteria<TValue> object specifying the comparison criteria.</param>
    /// <param name="selector">The expression specifying the property to compare against.</param>
    /// <returns>
    /// An IQueryable<T> that contains elements from the input sequence that satisfy the condition 
    /// specified by the NumberCriteria<TValue> object and the selector expression.
    /// </returns>
    public static IQueryable<T> WhereCriteria<T, TValue>(this IQueryable<T> queryable,
                                                 NumberCriteria<TValue> criteria,
                                                 Expression<Func<T, TValue>> selector)
        where T : class
        where TValue : IComparable<TValue>
    {
        switch (criteria.Operator)
        {
            case Operator.LowerStrict:
                return queryable.Where(Expression.Lambda<Func<T, bool>>(Expression.LessThan(selector.Body, Expression.Constant(criteria.Value)), selector.Parameters));

            case Operator.LowerOrEqual:
                return queryable.Where(Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(selector.Body, Expression.Constant(criteria.Value)), selector.Parameters));

            case Operator.Equal:
                return queryable.Where(Expression.Lambda<Func<T, bool>>(Expression.Equal(selector.Body, Expression.Constant(criteria.Value)), selector.Parameters));

            case Operator.GreaterStrict:
                return queryable.Where(Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(selector.Body, Expression.Constant(criteria.Value)), selector.Parameters));

            case Operator.GreaterOrEqual:
                return queryable.Where(Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(selector.Body, Expression.Constant(criteria.Value)), selector.Parameters));

            case Operator.Between:
                var greaterThanExpression = Expression.GreaterThanOrEqual(selector.Body, Expression.Constant(criteria.Value));
                var lessThanExpression = Expression.LessThanOrEqual(selector.Body, Expression.Constant(criteria.Value2));
                var andExpression = Expression.AndAlso(greaterThanExpression, lessThanExpression);
                return queryable.Where(Expression.Lambda<Func<T, bool>>(andExpression, selector.Parameters));

            default:
                throw new InvalidOperationException("Operator not supported.");
        }
    }
}
