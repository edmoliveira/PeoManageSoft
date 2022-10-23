using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    internal abstract class BaseRepository
    {
        #region Properties

        /// <summary>
        /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
        /// </summary>
        protected IDbContext DbContext { get; }
        /// <summary>
        /// Class to be used on one instance throughout the application per request
        /// </summary>
        protected IApplicationContext ApplicationContext { get; }
        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        protected IServiceProvider Provider { get; }
        /// <summary>
        /// Log
        /// </summary>
        protected ILogger Logger { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.BaseRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="logger">Log</param>
        public BaseRepository(
            IDbContext dbContext, 
            IApplicationContext applicationContext,
            IServiceProvider provider,
            ILogger logger)
        {
            DbContext = dbContext;
            ApplicationContext = applicationContext;
            Provider = provider;
            Logger = logger;
        }

        #endregion
    }
}
