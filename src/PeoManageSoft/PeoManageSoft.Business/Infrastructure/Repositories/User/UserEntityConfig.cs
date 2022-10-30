using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    #region Enums 

    /// <summary>
    /// User entity field
    /// </summary>
    public enum UserEntityField
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

    /// <summary>
    /// User entity configuration
    /// </summary>
    sealed class UserEntityConfig : BaseEntityConfig<UserEntity, UserEntityField>
    {
        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private static readonly Table _oTable = new("IUser");
        /// <summary>
        /// Id parameter configuration.
        /// </summary>
        private readonly ParameterConfig _idConfig = new("Id", DbType.Int64, 0, false, true, table: _oTable);
        /// <summary>
        /// IsActive parameter configuration.
        /// </summary>
        private readonly ParameterConfig _isActiveConfig = new("IsActive", DbType.Boolean, table: _oTable);
        /// <summary>
        /// Login parameter configuration.
        /// </summary>
        private readonly ParameterConfig _loginConfig = new("Login", DbType.String, 70, table: _oTable);
        /// <summary>
        /// Password parameter configuration.
        /// </summary>
        private readonly ParameterConfig _passwordConfig = new("Password", DbType.String, 500, table: _oTable);
        /// <summary>
        /// PasswordToken parameter configuration.
        /// </summary>
        private readonly ParameterConfig _passwordTokenConfig = new("PasswordToken", DbType.String, table: _oTable);
        /// <summary>
        /// Role parameter configuration.
        /// </summary>
        private readonly ParameterConfig _roleConfig = new("Role", DbType.Int32, table: _oTable);
        /// <summary>
        /// Name parameter configuration.
        /// </summary>
        private readonly ParameterConfig _nameConfig = new("Name", DbType.String, 200, table: _oTable);
        /// <summary>
        /// ShortName parameter configuration.
        /// </summary>
        private readonly ParameterConfig _shortNameConfig = new("ShortName", DbType.String, 50, table: _oTable);
        /// <summary>
        /// TitleId parameter configuration.
        /// </summary>
        private readonly ParameterConfig _titleIdConfig = new("TitleId", DbType.Int64, table: _oTable);
        /// <summary>
        /// DepartmentId parameter configuration.
        /// </summary>
        private readonly ParameterConfig _departmentIdConfig = new("DepartmentId", DbType.Int64, table: _oTable);
        /// <summary>
        /// Email parameter configuration.
        /// </summary>
        private readonly ParameterConfig _emailConfig = new("Email", DbType.String, 500, table: _oTable);
        /// <summary>
        /// BussinessPhone parameter configuration.
        /// </summary>
        private readonly ParameterConfig _bussinessPhoneConfig = new("BussinessPhone", DbType.String, 20, table: _oTable);
        /// <summary>
        /// MobilePhone parameter configuration.
        /// </summary>
        private readonly ParameterConfig _mobilePhoneConfig = new("MobilePhone", DbType.String, 20, table: _oTable);
        /// <summary>
        /// Location parameter configuration.
        /// </summary>
        private readonly ParameterConfig _locationConfig = new("Location", DbType.String, 50, table: _oTable);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserEntityConfig class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        public UserEntityConfig(IServiceProvider provider, IApplicationContext applicationContext)
            : base(_oTable, new View("UserView"),
                 new Procedure("sp_insert_user"),
                 new Procedure("sp_update_user"),
                 new Procedure("sp_delete_user"), provider, applicationContext)
        {
        }

        #endregion

        #region Methods

        #region protected

        protected override Dictionary<UserEntityField, ParameterConfig> GetParametersConfig()
        {
            return new()
            {
                {  UserEntityField.IsActive, _isActiveConfig },
                {  UserEntityField.Password, _passwordConfig },
                {  UserEntityField.PasswordToken, _passwordTokenConfig },
                {  UserEntityField.Role, _roleConfig },
                {  UserEntityField.Name, _nameConfig },
                {  UserEntityField.ShortName, _shortNameConfig },
                {  UserEntityField.TitleId, _titleIdConfig },
                {  UserEntityField.DepartmentId, _departmentIdConfig },
                {  UserEntityField.BussinessPhone, _bussinessPhoneConfig },
                {  UserEntityField.MobilePhone, _mobilePhoneConfig },
                {  UserEntityField.Location, _locationConfig },
            };
        }

        protected override Dictionary<UserEntityField, ParameterConfig> GetParametersConfigAndReadonly()
        {
            var dictionary = GetParametersConfig();

            dictionary.Add(UserEntityField.Id_Readonly, _idConfig);
            dictionary.Add(UserEntityField.Login_Readonly, _loginConfig);
            dictionary.Add(UserEntityField.Email_Readonly, _emailConfig);

            return dictionary;
        }

        protected override IEnumerable<IParameter> GetParametersToInsert(UserEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_loginConfig, entity.Login),
                CreateParameter(_passwordConfig, entity.Password),
                CreateParameter(_roleConfig, entity.Role),
                CreateParameter(_nameConfig, entity.Name),
                CreateParameter(_shortNameConfig, entity.ShortName),
                CreateParameter(_titleIdConfig, entity.TitleId),
                CreateParameter(_departmentIdConfig, entity.DepartmentId),
                CreateParameter(_emailConfig, entity.Email),
                CreateParameter(_bussinessPhoneConfig, entity.BussinessPhone),
                CreateParameter(_mobilePhoneConfig, entity.MobilePhone),
                CreateParameter(_locationConfig, entity.Location)
            };
        }

        protected override IEnumerable<IParameter> GetParametersToUpdate(UserEntity entity)
        {
            return new List<IParameter>
            {
                CreateParameter(_idConfig, entity.Id),
                CreateParameter(_isActiveConfig, entity.IsActive),
                CreateParameter(_roleConfig, entity.Role),
                CreateParameter(_nameConfig, entity.Name),
                CreateParameter(_shortNameConfig, entity.ShortName),
                CreateParameter(_titleIdConfig, entity.TitleId),
                CreateParameter(_departmentIdConfig, entity.DepartmentId),
                CreateParameter(_emailConfig, entity.Email),
                CreateParameter(_bussinessPhoneConfig, entity.BussinessPhone),
                CreateParameter(_mobilePhoneConfig, entity.MobilePhone)
            };
        }

        #endregion

        #endregion
    }
}
