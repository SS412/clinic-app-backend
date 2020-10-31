using AppPersistence.Repositiories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbCrudRepository(

            )
    }
}
