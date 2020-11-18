using AppPersistence.Enums;
using AppPersistence.Repositiories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Repositiories
{
    /// <summary>
    /// Repository for basic CRUD operations on a given entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class DbCrudRepository<TEntity, TPrimaryKey> : IReadOnlyRepository<TEntity, TPrimaryKey>, IWriteOnlyRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        protected readonly DbContext Context;

        public DbCrudRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetById<TResult>(TPrimaryKey id) =>
            await Context.Set<TEntity>().FindAsync(id).AsTask();

        public async Task<IReadOnlyList<TResult>> Get<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity>> order,
            string columnToBeOrdered,
            OrderDirection direction = OrderDirection.Ascending
        )
        {
            var results = Context.Set<TEntity>().Where(predicate);
            results = OrderBy(results, columnToBeOrdered, order, direction);
            return await results.Select(selector).ToListAsync();
        }

        private string GetOrder(OrderDirection direction) => direction == OrderDirection.Ascending ? "OrderBy" : "OrderByDescending";

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, Expression<Func<TEntity>> order, OrderDirection direction = OrderDirection.Ascending)
        {
            if (String.IsNullOrEmpty(columnName))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, "");
            MemberExpression property = Expression.Property(parameter, columnName);
            // LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = direction == OrderDirection.Ascending ? "OrderBy" : "OrderByDescending";
            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                  new Type[] { source.ElementType, property.Type },
                                  source.Expression, Expression.Quote(order));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
