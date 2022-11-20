using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Title encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class TitleRepository : BaseRepository<TitleEntity, TitleEntityField>, ITitleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public TitleRepository(
            IBaseEntityConfig<TitleEntity, TitleEntityField> entityConfig,
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            IMapper mapper,
            ILogger<TitleRepository> logger)
            : base(entityConfig, dbContext, applicationContext, provider, mapper, logger)
        {
        }

        #endregion

        #region Methods

        #region protected 

        /// <summary>
        /// Sets the unique identifier
        /// </summary>
        /// <param name="entity">Mapping to a database table</param>
        /// <param name="id">The unique identifier</param>
        protected override void SetId(TitleEntity entity, long id)
        {
            IEntity ientity = entity;

            ientity.SetId(id);
        }

        /// <summary>
        /// Sets the entity
        /// </summary>
        /// <param name="dataReaderGetValue">Functionality to fetch data from datareader based on entity settings.</param>
        /// <returns>Entity</returns>
        protected override TitleEntity SetEntity(IDataReaderGetValue dataReaderGetValue) =>
            Mapper.Map<TitleEntity>(dataReaderGetValue);

        #endregion

        #endregion
    }
}
