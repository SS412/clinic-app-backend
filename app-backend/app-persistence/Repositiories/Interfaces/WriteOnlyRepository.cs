using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPersistence.Repositiories.Interfaces
{
    /// <summary>
    /// Read only repository for DB Entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface WriteOnlyRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        /// <summary>
        /// Inserts or updates the specified entity depending on wether it has a primary key or not
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Save(TEntity entity);
        /// <summary>
        /// Inserts or updates the specified entities depending on wether they have a primary key or not
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task Save(IReadOnlyList<TEntity> entities);
        /// <summary>
        /// Deletes an entity with the given primary key, does nothing if an entity with the id is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteById(TPrimaryKey id);
        /// <summary>
        /// Deletes entities with the given list of primary keys, does nothing if an entity with the id is not found
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteById(IEnumerable<TPrimaryKey> ids);
    }
}
