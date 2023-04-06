using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Role
{
    #region Enums 

    /// <summary>
    /// Role Entity field
    /// </summary>
    internal enum RoleEntityField
    {
        /// <summary>
        /// Readonly
        /// </summary>
        Id_Readonly,
        /// <summary>
        /// Read and Write
        /// </summary>
        IsActive,
        /// <summary>
        /// Read and Write
        /// </summary>
        Name
    }

    #endregion

    /// <summary>
    /// Role entity configuration
    /// </summary>
    sealed class RoleEntityConfig : BaseEntityConfig<RoleEntity, RoleEntityField>
    {
        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private static readonly Table _oTable = new("IRole");
        /// <summary>
        /// Id parameter configuration.
        /// </summary>
        private readonly ParameterConfig _idConfig = new("Id", DbType.Int64, 0, false, true, table: _oTable);
        /// <summary>
        /// IsActive parameter configuration.
        /// </summary>
        private readonly ParameterConfig _isActiveConfig = new("IsActive", DbType.Boolean, table: _oTable);
        /// <summary>
        /// Name parameter configuration.
        /// </summary>
        private readonly ParameterConfig _nameConfig = new("Name", DbType.String, 200, table: _oTable);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Role.RoleEntityConfig class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        public RoleEntityConfig(IServiceProvider provider, IApplicationContext applicationContext)
            : base(_oTable, new View("RoleView"),
                 new Procedure("sp_insert_role"),
                 new Procedure("sp_update_role"),
                 new Procedure("sp_delete_role"), provider, applicationContext)
        {
        }

        #endregion

        #region Methods

        #region protected

        protected override Dictionary<RoleEntityField, ParameterConfig> GetParametersConfig()
        {
            return new()
            {
                {  RoleEntityField.IsActive, _isActiveConfig },
                {  RoleEntityField.Name, _nameConfig },
            };
        }

        protected override Dictionary<RoleEntityField, ParameterConfig> GetParametersConfigAndReadonly()
        {
            var dictionary = GetParametersConfig();

            dictionary.Add(RoleEntityField.Id_Readonly, _idConfig);

            return dictionary;
        }

        protected override IEnumerable<IParameter> GetParametersToInsert(RoleEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_nameConfig, entity.Name)
            };
        }

        protected override IEnumerable<IParameter> GetParametersToUpdate(RoleEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_idConfig, entity.Id),
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_nameConfig, entity.Name)
            };
        }

        #endregion

        #endregion
    }
}
