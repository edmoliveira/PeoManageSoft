using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class UserRepository : BaseRepository<UserEntity, UserEntityField>, IUserRepository
    {
        #region Fields

        /// <summary>
        /// The title entity configuration.
        /// </summary>
        private readonly IBaseEntityConfig<TitleEntity, TitleEntityField> _titleEntityConfig;
        /// <summary>
        /// The department entity configuration.
        /// </summary>
        private readonly IBaseEntityConfig<DepartmentEntity, DepartmentEntityField> _departmentEntityConfig;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public UserRepository(
            IBaseEntityConfig<UserEntity, UserEntityField> entityConfig,
            IBaseEntityConfig<TitleEntity, TitleEntityField> titleEntityConfig,
            IBaseEntityConfig<DepartmentEntity, DepartmentEntityField> departmentEntityConfig,
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            IMapper mapper,
            ILogger<UserRepository> logger)
            : base(entityConfig, dbContext, applicationContext, provider, mapper, logger)
        {
            _titleEntityConfig = titleEntityConfig;
            _departmentEntityConfig = departmentEntityConfig;
        }

        #endregion

        #region Methods

        #region protected 
        protected override void SetId(UserEntity entity, long id)
        {
            IEntity ientity = entity;

            ientity.SetId(id);
        }

        /// <summary>
        /// Sets the entity
        /// </summary>
        /// <param name="dataReaderGetValue">Functionality to fetch data from datareader based on entity settings.</param>
        /// <returns>Entity</returns>
        protected override UserEntity SetEntity(IDataReaderGetValue dataReaderGetValue)
        {
            var userEntity = oMapper.Map<UserEntity>(dataReaderGetValue);
            var titleEntity = oMapper.Map<TitleEntity>(
                new DataReaderGetValue<TitleEntity, TitleEntityField>(_titleEntityConfig, dataReaderGetValue.GetDataReader()));
            var departmentEntity = oMapper.Map<DepartmentEntity>(
                new DataReaderGetValue<DepartmentEntity, DepartmentEntityField>(_departmentEntityConfig, dataReaderGetValue.GetDataReader()));

            IUser user = userEntity;

            user.SetTitle(titleEntity);
            user.SetDepartment(departmentEntity);

            return userEntity;
        }

        #endregion

        #endregion
    }
}
