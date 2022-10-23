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
        #region Fields

        /// <summary>
        /// Table name.
        /// </summary>
        private static readonly string _nameOfTable = "IUser";
        /// <summary>
        /// Id parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _idConfig = new("Id", DbType.Int64, 0, false, true);
        /// <summary>
        /// IsActive parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _isActiveConfig = new("IsActive", DbType.Boolean);
        /// <summary>
        /// Login parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _loginConfig = new("Login", DbType.String, 70);
        /// <summary>
        /// Password parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _passwordConfig = new("Password", DbType.String, 500);
        /// <summary>
        /// PasswordToken parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _passwordTokenConfig = new("PasswordToken", DbType.String);
        /// <summary>
        /// Role parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _roleConfig = new("Role", DbType.Int32);
        /// <summary>
        /// Name parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _nameConfig = new("Name", DbType.String, 200);
        /// <summary>
        /// ShortName parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _shortNameConfig = new("ShortName", DbType.String, 50);
        /// <summary>
        /// TitleId parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _titleIdConfig = new("TitleId", DbType.Int64);
        /// <summary>
        /// DepartmentId parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _departmentIdConfig = new("DepartmentId", DbType.Int64);
        /// <summary>
        /// Email parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _emailConfig = new("Email", DbType.String, 500);
        /// <summary>
        /// BussinessPhone parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _bussinessPhoneConfig = new("BussinessPhone", DbType.String, 20);
        /// <summary>
        /// MobilePhone parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _mobilePhoneConfig = new("MobilePhone", DbType.String, 20);
        /// <summary>
        /// Location parameter configuration.
        /// </summary>
        private static readonly ParameterConfig _locationConfig = new("Location", DbType.String, 50);

        #endregion

        #region Methods

        #region public

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
        /// Stored procedures "SELECT BY ID"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, string splitOn, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_select_by_id_user", parameterId: new { Id = id }, splitOn: "TitleId,DepartmentId", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT"
        /// </summary>
        /// <returns>Returns the sql statement, splitOn and the command type.</returns>
        public static (string sqlStatement, string splitOn, CommandType commandType) GetSelectSqlStatement()
        {
            return (sqlStatement: "sp_select_user", splitOn: "TitleId,DepartmentId", CommandType.StoredProcedure);
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
        /// The sql statement to update the field "Location"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="location">Location</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) 
            GetUpdateLocationSqlStatement(
            IServiceProvider provider, 
            string location, 
            IApplicationContext applicationContext)
        {
            var parameterList = BaseEntityConfig.GetUpdateParameters(provider, applicationContext);

            parameterList.Add(BaseEntityConfig.CreateParameter(provider, _locationConfig, location));

            var sql = BaseEntityConfig.GetUpdateSqlStatement(_nameOfTable, parameterList);

            return (sqlStatement: sql, parameters: parameterList, CommandType.Text);
        }

        /// <summary>
        /// Stored procedures "VALIDATE INSERT"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="entity">Entity user.</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameters, CommandType commandType) 
            GetValidateInsertSqlStatement(
            IServiceProvider provider,
            UserEntity entity)
        {
            var parameterList = new List<IParameter>
            {
                BaseEntityConfig.CreateParameter(provider, _loginConfig, entity.Login),
                BaseEntityConfig.CreateParameter(provider, _titleIdConfig, entity.TitleId),
                BaseEntityConfig.CreateParameter(provider, _departmentIdConfig, entity.DepartmentId),
                BaseEntityConfig.CreateParameter(provider, _emailConfig, entity.Email)
            };

            return (sqlStatement: "sp_validate_insert_user", parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "VALIDATE UPDATE"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="entity">Entity user.</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameters, CommandType commandType) 
            GetValidateUpdateSqlStatement(
            IServiceProvider provider,
            UserEntity entity)
        {
            var parameterList = new List<IParameter>
            {
                BaseEntityConfig.CreateParameter(provider, _idConfig, entity.Id),
                BaseEntityConfig.CreateParameter(provider, _titleIdConfig, entity.TitleId),
                BaseEntityConfig.CreateParameter(provider, _departmentIdConfig, entity.DepartmentId),
                BaseEntityConfig.CreateParameter(provider, _emailConfig, entity.Email)
            };

            return (sqlStatement: "sp_validate_update_user", parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SP_SELECT_AUTH_User"
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, string splitOn, CommandType commandType) GetSelectUserSqlStatement(string username, string password)
        {
            return (sqlStatement: "sp_select_auth_user", parameters: new { Username = username, Password = password }, splitOn: "TitleId,DepartmentId", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SP_UPDATE_CHANGE_PASS_User"
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">User old password</param>
        /// <param name="newPassword">User new password</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) 
            GetUpdateChangePassSqlStatement(
            IServiceProvider provider,
            string username, 
            string oldPassword, 
            string newPassword, 
            IApplicationContext applicationContext)
        {
            var parameterList = BaseEntityConfig.GetUpdateParameters(provider, applicationContext);

            parameterList.Add(BaseEntityConfig.CreateParameter(provider, new("Username", DbType.String, 70), username));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, new("Password", DbType.String, 500), oldPassword));
            parameterList.Add(BaseEntityConfig.CreateParameter(provider, new("Newpassword", DbType.String, 500), newPassword));

            return (sqlStatement: "sp_update_change_pass_user", parameters: parameterList, CommandType.StoredProcedure);
        }

        #endregion

        #endregion
    }
}
