using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    #region Enums 

    /// <summary>
    /// Title Entity field
    /// </summary>
    internal enum TitleEntityField
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
    /// Title entity configuration
    /// </summary>
    sealed class TitleEntityConfig : BaseEntityConfig<TitleEntity, TitleEntityField>
    {
        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private static readonly Table _oTable = new("Title");
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
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleEntityConfig class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        public TitleEntityConfig(IServiceProvider provider, IApplicationContext applicationContext)
            : base(_oTable, new View("TitleView"),
                 new Procedure("sp_insert_title"),
                 new Procedure("sp_update_title"),
                 new Procedure("sp_delete_title"), provider, applicationContext)
        {
        }

        #endregion

        #region Methods

        #region protected

        protected override Dictionary<TitleEntityField, ParameterConfig> GetParametersConfig()
        {
            return new()
            {
                {  TitleEntityField.IsActive, _isActiveConfig },
                {  TitleEntityField.Name, _nameConfig },
            };
        }

        protected override Dictionary<TitleEntityField, ParameterConfig> GetParametersConfigAndReadonly()
        {
            var dictionary = GetParametersConfig();

            dictionary.Add(TitleEntityField.Id_Readonly, _idConfig);

            return dictionary;
        }

        protected override IEnumerable<IParameter> GetParametersToInsert(TitleEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_nameConfig, entity.Name)
            };
        }

        protected override IEnumerable<IParameter> GetParametersToUpdate(TitleEntity entity)
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
