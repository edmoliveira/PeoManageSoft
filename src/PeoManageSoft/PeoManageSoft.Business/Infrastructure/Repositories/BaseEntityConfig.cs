using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Entity configuration base class
    /// </summary>
    static class BaseEntityConfig
    {
        #region Methods

        #region public

        /// <summary>
        /// Gets update command of the entity.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>SQL statement</returns>
        public static string GetUpdateSqlStatement(string tableName, IEnumerable<IParameter> parameters)
        {
            if (tableName is null) { throw new ArgumentException($"The Argument '{nameof(tableName)}' is null"); }
            if (parameters is null) { throw new ArgumentException($"The Argument '{nameof(parameters)}' is null"); }

            IParameter parameterId = parameters.Where(c => c.IsUniqueIdentifier).FirstOrDefault();

            if (parameterId is null) { throw new EntityIdNotFoundException(); }

            return "UPDATE @TABLE SET @FIELDS_VALUES WHERE @ID = @ID_VALUE"
                    .Replace("@TABLE", tableName)
                    .Replace("@FIELDS_VALUES", GetFieldsAndParameters(parameters, false))
                    .Replace("@ID", parameterId.SourceColumn)
                    .Replace("@ID_VALUE", parameterId.ParameterName);
        }

        /// <summary>
        /// Gets the insert parameters.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the insert parameters</returns>
        public static IList<IParameter> GetInsertParameters(IServiceProvider provider, IApplicationContext applicationContext)
        {
            return new List<IParameter>
            {
                CreateParameter(provider, new ("RequestId", DbType.String, 500), applicationContext.RequestId),
                CreateParameter(provider, new ("CreationUser", DbType.String, 70), applicationContext.LoggedUser.User),
                CreateParameter(provider, new ("CreationDate", DbType.DateTime), DateTime.Now)
            };
        }

        /// <summary>
        /// Gets the update parameters.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the update parameters</returns>
        public static IList<IParameter> GetUpdateParameters(IServiceProvider provider, IApplicationContext applicationContext)
        {
            return new List<IParameter>
            {
                CreateParameter(provider, new ("RequestId", DbType.String, 500), applicationContext.RequestId),
                CreateParameter(provider, new ("UpdatedUser", DbType.String, 70), applicationContext.LoggedUser.User),
                CreateParameter(provider, new ("UpdatedDate", DbType.DateTime), DateTime.Now)
            };
        }

        /// <summary>
        /// Create a parameter that represents to a Command object.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="parameterConfig">Parameter configuration.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>Parameter that represents to a Command object.</returns>
        public static IParameter CreateParameter(
            IServiceProvider provider,
            ParameterConfig parameterConfig,
            object value = null)
        {
            if (provider is null) { throw new ArgumentException($"The Argument '{nameof(provider)}' is null"); }
            if (parameterConfig is null) { throw new ArgumentException($"The Argument '{nameof(parameterConfig)}' is null"); }

            if (provider.GetService(typeof(IParameter)) is not IParameter parameter)
            {
                throw new ProviderServiceNotFoundException(nameof(IParameter));
            }

            parameter.ParameterName = string.Concat("@", parameterConfig.ParameterName);
            parameter.SourceColumn = parameterConfig.SourceColumn;
            parameter.DbType = parameterConfig.DbType;
            parameter.Size = parameterConfig.Size;
            parameter.IsNullable = parameterConfig.IsNullable;
            parameter.IsUniqueIdentifier = parameterConfig.IsUniqueIdentifier;
            parameter.Precision = parameterConfig.Precision;
            parameter.Scale = parameterConfig.Scale;
            parameter.Value = value;

            return parameter;
        }

        #endregion

        #region private

        /// <summary>
        /// Gets entity fields and parameters
        /// </summary>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <param name="canUniqueIdentifier">Indicates whether it can return the entity id.</param>
        /// <returns>Fields and Parameters Ex:Field1 = @Parameter1,Field1 = @Parameter2</returns>
        private static string GetFieldsAndParameters(IEnumerable<IParameter> parameters, bool canUniqueIdentifier = true)
        {
            if (parameters is null) { throw new ArgumentException($"The Argument '{nameof(parameters)}' is null"); }

            IEnumerable<IParameter> list = canUniqueIdentifier ? parameters : parameters.Where(c => !c.IsUniqueIdentifier);

            return list
                    .Select(c => string.Concat(c.SourceColumn, " = ", c.ParameterName))
                    .Aggregate((result, item) => string.Concat(result, ",", item));
        }

        #endregion

        #endregion
    }
}
