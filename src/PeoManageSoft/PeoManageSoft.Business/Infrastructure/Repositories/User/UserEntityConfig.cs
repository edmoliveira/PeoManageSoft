using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User entity stored procedures
    /// </summary>
    static class UserEntityConfig
    {
        #region Enums 

        /// <summary>
        /// Entity field
        /// </summary>
        public enum EntityField
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
            /// Readonly
            /// </summary>
            Login_Readonly,
            /// <summary>
            /// Read and Write
            /// </summary>
            Password,
            /// <summary>
            /// Read and Write
            /// </summary>
            PasswordToken,
            /// <summary>
            /// Read and Write
            /// </summary>
            Role,
            /// <summary>
            /// Read and Write
            /// </summary>
            Name,
            /// <summary>
            /// Read and Write
            /// </summary>
            ShortName,
            /// <summary>
            /// Read and Write
            /// </summary>
            TitleId,
            /// <summary>
            /// Read and Write
            /// </summary>
            DepartmentId,
            /// <summary>
            /// Readonly
            /// </summary>
            Email_Readonly,
            /// <summary>
            /// Read and Write
            /// </summary>
            BussinessPhone,
            /// <summary>
            /// Read and Write
            /// </summary>
            MobilePhone,
            /// <summary>
            /// Read and Write
            /// </summary>
            Location
        }

        #endregion

        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private static readonly Table _oTable = new("IUser");
        /// <summary>
        /// View object.
        /// </summary>
        private static readonly View _oView = new("UserView");
        /// <summary>
        /// Id parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _idConfig = new("Id", DbType.Int64, 0, false, true, table: _oTable);
        /// <summary>
        /// IsActive parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _isActiveConfig = new("IsActive", DbType.Boolean, table: _oTable);
        /// <summary>
        /// Login parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _loginConfig = new("Login", DbType.String, 70, table: _oTable);
        /// <summary>
        /// Password parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _passwordConfig = new("Password", DbType.String, 500, table: _oTable);
        /// <summary>
        /// PasswordToken parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _passwordTokenConfig = new("PasswordToken", DbType.String, table: _oTable);
        /// <summary>
        /// Role parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _roleConfig = new("Role", DbType.Int32, table: _oTable);
        /// <summary>
        /// Name parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _nameConfig = new("Name", DbType.String, 200, table: _oTable);
        /// <summary>
        /// ShortName parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _shortNameConfig = new("ShortName", DbType.String, 50, table: _oTable);
        /// <summary>
        /// TitleId parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _titleIdConfig = new("TitleId", DbType.Int64, table: _oTable);
        /// <summary>
        /// DepartmentId parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _departmentIdConfig = new("DepartmentId", DbType.Int64, table: _oTable);
        /// <summary>
        /// Email parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _emailConfig = new("Email", DbType.String, 500, table: _oTable);
        /// <summary>
        /// BussinessPhone parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _bussinessPhoneConfig = new("BussinessPhone", DbType.String, 20, table: _oTable);
        /// <summary>
        /// MobilePhone parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _mobilePhoneConfig = new("MobilePhone", DbType.String, 20, table: _oTable);
        /// <summary>
        /// Location parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _locationConfig = new("Location", DbType.String, 50, table: _oTable);

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets a function to look up the entity property value.
        /// </summary>
        /// <returns>Func<EntityField, IDataReader, object></returns>
        public static Func<EntityField, IDataReader, object> GetFuncSearchValue()
        {
            var searchArray = GetParametersConfigAndReadonly();

            return (entityField, dataReader) =>
            {
                ParameterConfig parameterConfig = searchArray.Where(p => p.Key == entityField).First().Value;

                return dataReader.GetValue(dataReader.GetOrdinal(parameterConfig.SourceColumnAlias));
            };
        }

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, the parameter id and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetDeleteSqlStatement(long id)
        {
            return (sqlStatement: "sp_delete_user", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "EXISTS BY ID"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetExistsByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_exists_by_id_user", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="entity">Entity user.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, object parameters, CommandType commandType)
            GetInsertSqlStatement(
            IServiceProvider provider,
            UserEntity entity,
            IApplicationContext applicationContext)
        {
            var parameterList = BaseEntityConfig.GetInsertParameters(provider, applicationContext);

            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _isActiveConfig, entity.IsActive));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _loginConfig, entity.Login));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _passwordConfig, entity.Password));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _roleConfig, entity.Role));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _nameConfig, entity.Name));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _shortNameConfig, entity.ShortName));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _titleIdConfig, entity.TitleId));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _departmentIdConfig, entity.DepartmentId));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _emailConfig, entity.Email));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _bussinessPhoneConfig, entity.BussinessPhone));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _mobilePhoneConfig, entity.MobilePhone));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _locationConfig, entity.Location));

            return (sqlStatement: "sp_insert_user", parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Gets select command of the entity by id.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameterId and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType)
            GetSelectByIdSqlStatement(
            IServiceProvider provider,
            long id)
        {
            var sql = BaseEntityConfig.GetSelectByIdSqlStatement(_oView, _idConfig);

            return (sqlStatement: sql,
                parameterId: BaseEntityConfig.CreateParameter(provider, _idConfig, id),
                CommandType.Text);
        }

        /// <summary>
        /// Gets select command of the entity by rules.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="rule"></param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        public static (string sqlStatement, object parameters, CommandType commandType)
            GetSelectByRulesSqlStatement(
            IServiceProvider provider,
            IRule<EntityField> rule)
        {
            var parametersConfig = GetParametersConfigAndReadonly();

            var sql = BaseEntityConfig.GetSelectByRulesSqlStatement(
                provider,
                _oView,
                rule,
                entityField => parametersConfig[entityField],
                out var parameterList);

            return (sqlStatement: sql,
                parameters: parameterList,
                CommandType.Text);
        }

        /// <summary>
        /// Gets select all command of the entity.
        /// </summary>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) GetSelectAllSqlStatement()
        {
            var sql = BaseEntityConfig.GetSelectAllSqlStatement(_oView);

            return (sqlStatement: sql, parameters: null, CommandType.Text);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="entity">Entity user.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, object parameters, CommandType commandType)
            GetUpdateSqlStatement(
            IServiceProvider provider,
            UserEntity entity,
            IApplicationContext applicationContext)
        {
            var parameterList = BaseEntityConfig.GetUpdateParameters(provider, applicationContext);

            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _idConfig, entity.Id));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _isActiveConfig, entity.IsActive));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _roleConfig, entity.Role));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _nameConfig, entity.Name));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _shortNameConfig, entity.ShortName));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _titleIdConfig, entity.TitleId));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _departmentIdConfig, entity.DepartmentId));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _emailConfig, entity.Email));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _bussinessPhoneConfig, entity.BussinessPhone));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _mobilePhoneConfig, entity.MobilePhone));

            return (sqlStatement: "sp_update_user", parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// The sql statement to update the fields
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="fields">Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType)
            GetPatchSqlStatement(
            IServiceProvider provider,
            IEnumerable<Field<EntityField>> fields,
            long id,
            IApplicationContext applicationContext)
        {
            var parametersConfig = GetParametersConfig();

            var parameterList = BaseEntityConfig.GetUpdateParameters(provider, applicationContext);

            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _idConfig, id));

            foreach (var field in fields)
            {
                parameterList.Add(BaseEntityConfig.CreateParameter(provider, parametersConfig[field.Type], field.Value));
            }

            var sql = BaseEntityConfig.GetUpdateSqlStatement(_oTable, parameterList);

            return (sqlStatement: sql, parameters: parameterList, CommandType.Text);
        }

        #endregion

        #region private

        /// <summary>
        /// Gets parameter setting based on field type and readonly.
        /// </summary>
        /// <returns>Returns a Dictionary with field type and parameter configuration.</returns>
        private static Dictionary<EntityField, ParameterConfig> GetParametersConfigAndReadonly()
        {
            var dictionary = GetParametersConfig();

            dictionary.Add(EntityField.Id_Readonly, _idConfig);
            dictionary.Add(EntityField.Login_Readonly, _loginConfig);
            dictionary.Add(EntityField.Email_Readonly, _emailConfig);

            return dictionary;
        }

        /// <summary>
        /// Gets parameter setting based on field type.
        /// </summary>
        /// <returns>Returns a Dictionary with field type and parameter configuration.</returns>
        private static Dictionary<EntityField, ParameterConfig> GetParametersConfig()
        {
            return new()
            {
                {  EntityField.IsActive, _isActiveConfig },
                {  EntityField.Password, _passwordConfig },
                {  EntityField.PasswordToken, _passwordTokenConfig },
                {  EntityField.Role, _roleConfig },
                {  EntityField.Name, _nameConfig },
                {  EntityField.ShortName, _shortNameConfig },
                {  EntityField.TitleId, _titleIdConfig },
                {  EntityField.DepartmentId, _departmentIdConfig },
                {  EntityField.BussinessPhone, _bussinessPhoneConfig },
                {  EntityField.MobilePhone, _mobilePhoneConfig },
                {  EntityField.Location, _locationConfig },
            };
        }

        #endregion

        #endregion
    }
}
