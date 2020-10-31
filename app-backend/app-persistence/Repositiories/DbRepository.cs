using app_persistence;
using System;
using System.Threading.Tasks;

namespace AppPersistence.Repositiories
{
    /// <summary>
    /// Repository for running database operations
    /// </summary>
    public class DbRepository
    {
        public DbRepository(Func<Db> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        /// <summary>
        /// Function for obtaining database sessions
        /// </summary>
        private readonly Func<Db> dbFactory;

    }
}
