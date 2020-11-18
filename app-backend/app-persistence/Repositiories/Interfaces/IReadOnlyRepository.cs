using AppPersistence.DTOs;
using AppPersistence.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppPersistence.Repositiories.Interfaces
{
    /// <summary>
    /// Read only repository for DB Entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IReadOnlyRepository<TEntity, TPrimaryKey> where TEntity: class
    {
        /// <summary>
        /// Returns the entity with the given primary key, returns null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(TPrimaryKey id);
        /// <summary>
        /// Returns all entities that meet the specified filter and transforms them using the specified selector.
        /// Default behavior returns them in ascendng ordr by primary key.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="selector"></param>
        /// <param name="filter"></param>
        /// <param name="order"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        Task<IReadOnlyList<TResult>> Get<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TOrder>> order,
            OrderDirection direction = OrderDirection.Ascending
        );
        /// <summary>
        /// Returns all entities that meet the specified filter and transforms them using the specified selector,
        /// in paged format
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="selector"></param>
        /// <param name="filter"></param>
        /// <param name="order"></param>
        /// <param name="pageable"></param>
        /// <returns></returns>
        Task<Page<TResult>> GetPage<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TResult, TOrder>> order,
            Pageable pageable
        );
        /// <summary>
        /// Determines if any entities meet the specified filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Executes special queries on an entity repository
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="queryAction"></param>
        /// <returns></returns>
        Task<TResult> Query<TResult>(Func<IQueryable<TEntity>, Task<TResult>> queryAction);
        /// <summary>
        /// Determines if the give entity has an existing relation to another entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <param name="skippedEntityRelations"></param>
        /// <returns></returns>
        Task<bool> HasRelations(TEntity entity, int id, Type[] skippedEntityRelations = null);


    }
}
