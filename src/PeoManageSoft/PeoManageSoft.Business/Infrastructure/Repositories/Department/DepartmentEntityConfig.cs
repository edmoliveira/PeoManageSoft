using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    #region Enums 

    /// <summary>
    /// Department Entity field
    /// </summary>
    public enum DepartmentEntityField
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
    /// Department entity configuration
    /// </summary>
    sealed class DepartmentEntityConfig : BaseEntityConfig<DepartmentEntity, DepartmentEntityField>
    {
        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private static readonly Table _oTable = new("Department");
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
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentEntityConfig class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        public DepartmentEntityConfig(IServiceProvider provider, IApplicationContext applicationContext)
            : base(_oTable, new View("DepartmentView"),
                 new Procedure("sp_insert_department"),
                 new Procedure("sp_update_department"),
                 new Procedure("sp_delete_department"), provider, applicationContext)
        {
        }

        #endregion

        #region Methods

        #region protected

        protected override Dictionary<DepartmentEntityField, ParameterConfig> GetParametersConfig()
        {
            return new()
            {
                {  DepartmentEntityField.IsActive, _isActiveConfig },
                {  DepartmentEntityField.Name, _nameConfig },
            };
        }

        protected override Dictionary<DepartmentEntityField, ParameterConfig> GetParametersConfigAndReadonly()
        {
            var dictionary = GetParametersConfig();

            dictionary.Add(DepartmentEntityField.Id_Readonly, _idConfig);

            return dictionary;
        }

        protected override IEnumerable<IParameter> GetParametersToInsert(DepartmentEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_nameConfig, entity.Name)
            };
        }

        protected override IEnumerable<IParameter> GetParametersToUpdate(DepartmentEntity entity)
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
