using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using System.Data;
using System.Text;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Entity configuration base class
    /// </summary>
    /// <typeparam name="TEntity">Mapping to a database table</typeparam>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    abstract class BaseEntityConfig<TEntity, TEntityField> : IBaseEntityConfig<TEntity, TEntityField>
    {
        #region Fields

        /// <summary>
        /// Table object.
        /// </summary>
        private readonly Table _table;
        /// <summary>
        /// View object.
        /// </summary>
        private readonly View _view;
        /// <summary>
        /// Procedure object "INSERT".
        /// </summary>
        private readonly Procedure _insertProcedure;
        /// <summary>
        /// Procedure object "UPDATE".
        /// </summary>
        private readonly Procedure _updateProcedure;
        /// <summary>
        /// Procedure object "DELETE".
        /// </summary>
        private readonly Procedure _deleteProcedure;
        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// Class to be used on one instance throughout the application per request
        /// </summary>
        private readonly IApplicationContext _applicationContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.BaseEntityConfig class.
        /// </summary>
        /// <param name="table">Table object.</param>
        /// <param name="view">View object.</param>
        /// <param name="insertProcedure">Procedure object "INSERT".</param>
        /// <param name="updateProcedure">Procedure object "UPDATE".</param>
        /// <param name="deleteProcedure">Procedure object "DELETE".</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        public BaseEntityConfig(
            Table table,
            View view,
            Procedure insertProcedure,
            Procedure updateProcedure,
            Procedure deleteProcedure,
            IServiceProvider provider,
            IApplicationContext applicationContext
            )
        {
            _table = table;
            _view = view;
            _insertProcedure = insertProcedure;
            _updateProcedure = updateProcedure;
            _deleteProcedure = deleteProcedure;
            _provider = provider;
            _applicationContext = applicationContext;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets a function to look up the entity property value.
        /// </summary>
        /// <returns>Func<object, IDataReader, object></returns>
        public Func<object, IDataReader, object> GetFuncSearchValue()
        {
            var searchArray = GetParametersConfigAndReadonly();

            return (entityField, dataReader) =>
            {
                ParameterConfig parameterConfig = searchArray.Where(p => p.Key.Equals(entityField)).First().Value;

                var index = dataReader.GetOrdinal(parameterConfig.SourceColumnAlias);

                return !dataReader.IsDBNull(index) ? dataReader.GetValue(index) : null;
            };
        }

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetDeleteSqlStatement(long id)
        {
            var parameterConfigId = GetParameterConfigId();

            return (
                sqlStatement: _deleteProcedure.Name,
                parameters: new List<IParameter> { CreateParameter(parameterConfigId, id) },
                CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <param name="entity">Entity user.</param>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetInsertSqlStatement(TEntity entity)
        {
            var parameterList = GetLogParametersToInsert();

            foreach (var item in GetParametersToInsert(entity))
            {
                parameterList.Add(item);
            }

            return (sqlStatement: _insertProcedure.Name, parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Gets select exists command of the entity by id.
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetExistsByIdSqlStatement(long id)
        {
            var parameterConfigId = GetParameterConfigId();

            return (
                sqlStatement: GetSelectExistsByIdSqlStatement(parameterConfigId),
                parameters: new List<IParameter> { CreateParameter(parameterConfigId, id) },
                CommandType.Text);
        }

        /// <summary>
        /// Gets select command of the entity by id.
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            var parameterConfigId = GetParameterConfigId();

            return (sqlStatement: GetSelectSqlStatement(parameterConfigId),
                parameters: new List<IParameter> { CreateParameter(parameterConfigId, id) },
                CommandType.Text);
        }

        /// <summary>
        /// Gets select command of the entity by rules.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectByRulesSqlStatement(IRule<TEntityField> rule)
        {
            var parametersConfig = GetParametersConfigAndReadonly();

            var sql = GetSelectByRulesSqlStatement(
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
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectAllSqlStatement()
        {
            return (sqlStatement: GetSelectSqlStatement(null), parameters: null, CommandType.Text);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <param name="entity">Entity user.</param>
        /// <returns>Returns the sql statement,parameters and the command type.</returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetUpdateSqlStatement(TEntity entity)
        {
            var parameterList = GetLogParametersToUpdate();

            foreach (var item in GetParametersToUpdate(entity))
            {
                parameterList.Add(item);
            }

            return (sqlStatement: _updateProcedure.Name, parameters: parameterList, CommandType.StoredProcedure);
        }

        /// <summary>
        /// The sql statement to update the fields
        /// </summary>
        /// <param name="fields">Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetPatchSqlStatement(IEnumerable<Field<TEntityField>> fields, long id)
        {
            var parameterConfigId = GetParameterConfigId();

            var parametersConfig = GetParametersConfig();

            var parameterList = GetLogParametersToUpdate();

            parameterList.Add(CreateParameter(parameterConfigId, id));

            foreach (var field in fields)
            {
                parameterList.Add(CreateParameter(parametersConfig[field.Type], field.Value));
            }

            return (sqlStatement: GetPatchSqlStatement(parameterList), parameters: parameterList, CommandType.Text);
        }

        #endregion

        #region protected

        /// <summary>
        /// Gets parameter setting based on field type and readonly.
        /// </summary>
        /// <returns>Returns a Dictionary with field type and parameter configuration.</returns>
        protected abstract Dictionary<TEntityField, ParameterConfig> GetParametersConfigAndReadonly();

        /// <summary>
        /// Gets parameter setting based on field type.
        /// </summary>
        /// <returns>Returns a Dictionary with field type and parameter configuration.</returns>
        protected abstract Dictionary<TEntityField, ParameterConfig> GetParametersConfig();

        /// <summary>
        /// Gets a parameter list to insert command.
        /// </summary>
        /// <param name="entity">Mapping to a database table</param>
        /// <returns>Returns the parameter list to insert command.</returns>
        protected abstract IEnumerable<IParameter> GetParametersToInsert(TEntity entity);

        /// <summary>
        /// Gets a parameter list to update command.
        /// </summary>
        /// <param name="entity">Mapping to a database table</param>
        /// <returns>Returns the parameter list to update command.</returns>
        protected abstract IEnumerable<IParameter> GetParametersToUpdate(TEntity entity);

        /// <summary>
        /// Gets the identifier parameter configuration.
        /// </summary>
        /// <returns>Returns the identifier parameter configuration.</returns>
        /// <exception cref="EntityIdNotFoundException">Represents errors that occur when base entity tries to get a parameter id.</exception>
        protected ParameterConfig GetParameterConfigId()
        {
            var parametersConfig = GetParametersConfigAndReadonly().Select(p => p.Value);

            var parameterConfigId = parametersConfig.Where(c => c.IsUniqueIdentifier).FirstOrDefault();

            if (parameterConfigId is null) { throw new EntityIdNotFoundException(); }

            return parameterConfigId;
        }

        /// <summary>
        /// Create a parameter that represents to a Command object.
        /// </summary>
        /// <param name="parameterConfig">Parameter configuration.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>Parameter that represents to a Command object.</returns>
        protected IParameter CreateParameter(ParameterConfig parameterConfig, object value = null)
        {
            if (parameterConfig is null) { throw new ArgumentException($"The Argument '{nameof(parameterConfig)}' is null"); }

            if (_provider.GetService(typeof(IParameter)) is not IParameter parameter)
            {
                throw new ProviderServiceNotFoundException(nameof(IParameter));
            }

            parameter.ParameterName = parameterConfig.ParameterName;
            parameter.Direction = parameterConfig.Direction;
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
        /// Gets select exists command of the entity by id.
        /// </summary>
        /// <param name="parameterId">Identifier Parameter configuration.</param>
        /// <returns>SQL statement</returns>
        private string GetSelectExistsByIdSqlStatement(ParameterConfig parameterId)
        {
            var sqlStatement = $@"
                SELECT CAST(1 AS BIT) FROM {_table.Name} 
                WHERE {parameterId.SourceColumn} = {parameterId.ParameterName}                 
            ";

            return sqlStatement;
        }

        /// <summary>
        /// Gets select by rules command of the entity.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="rule">Rules to filter the data</param>
        /// <param name="searchParameter">Search for parameter in entity configuration</param>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>SQL statement</returns>
        private string GetSelectByRulesSqlStatement(IRule<TEntityField> rule, Func<TEntityField, ParameterConfig> searchParameter, out IEnumerable<IParameter> parameters)
        {
            var paramList = new List<IParameter>();

            var sqlStatement = GetSelectSqlStatement(null);

            sqlStatement += $"WHERE {GetRules(rule, paramList, searchParameter)}";

            parameters = paramList;

            return sqlStatement;
        }

        /// <summary>
        /// Gets patch command of the entity.
        /// </summary>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>SQL statement</returns>
        private string GetPatchSqlStatement(IEnumerable<IParameter> parameters)
        {
            if (parameters is null) { throw new ArgumentException($"The Argument '{nameof(parameters)}' is null"); }

            IParameter parameterId = parameters.Where(c => c.IsUniqueIdentifier).FirstOrDefault();

            if (parameterId is null) { throw new EntityIdNotFoundException(); }

            return $@"
                UPDATE {_table.Name} SET {GetFieldsAndParameters(parameters, false)} 
                WHERE {parameterId.SourceColumn} = {parameterId.ParameterName}
            ";
        }

        /// <summary>
        /// Gets the log parameters to insert.
        /// </summary>
        /// <returns>Returns the parameters</returns>
        private IList<IParameter> GetLogParametersToInsert()
        {
            return new List<IParameter>
            {
                CreateParameter(new ("RequestId", DbType.String, 500), _applicationContext.RequestId),
                CreateParameter(new ("CreationUser", DbType.String, 70), _applicationContext.LoggedUser.User),
                CreateParameter(new ("CreationDate", DbType.DateTime), DateTime.Now)
            };
        }

        /// <summary>
        /// Gets the log parameters to update.
        /// </summary>
        /// <returns>Returns the parameters</returns>
        private IList<IParameter> GetLogParametersToUpdate()
        {
            return new List<IParameter>
            {
                CreateParameter(new ("RequestId", DbType.String, 500), _applicationContext.RequestId),
                CreateParameter(new ("UpdatedUser", DbType.String, 70), _applicationContext.LoggedUser.User),
                CreateParameter(new ("UpdatedDate", DbType.DateTime), DateTime.Now)
            };
        }

        /// <summary>
        /// Gets rules to filter the data
        /// </summary>
        /// <param name="rule">Rules to filter the data</param>
        /// <param name="parameters">Parameter list to a command object</param>
        /// <param name="searchParameter">Search for parameter in entity configuration</param>
        /// <param name="canSqlOperator">Indicates whether it can put the sql operator.</param>
        /// <returns>Rules Ex: Field1 = '1' or Field2 <> '45'</returns>
        private string GetRules(IRule<TEntityField> rule, IList<IParameter> parameters, Func<TEntityField, ParameterConfig> searchParameter, bool canSqlOperator = true)
        {
            StringBuilder builder = new();

            builder.Append('(');

            if (canSqlOperator)
            {
                SearchSqlOperator(rule, sqlOperator =>
                {
                    builder.Append(' ');
                    builder.Append(sqlOperator);
                    builder.Append(' ');
                });
            }

            if (rule.Rules?.Count > 0)
            {
                foreach (var childRule in rule.Rules)
                {
                    SearchSqlOperator(childRule, sqlOperator =>
                    {
                        builder.Append(' ');
                        builder.Append(sqlOperator);
                        builder.Append(' ');
                    });

                    ParameterConfig parameterConfig = searchParameter(childRule.EntityField);

                    if (parameterConfig is not null)
                    {
                        var comparisonOperator = SearchSqlComparisonOperators(childRule);

                        if (childRule.ComparisonOperator == SqlComparisonOperator.In)
                        {
                            if (childRule.Value is not System.Collections.IEnumerable enumerable)
                            {
                                throw new ArrayTypeMismatchException("Value is not array.");
                            }

                            builder.Append(parameterConfig.SourceColumnAlias);
                            builder.Append(' ');
                            builder.Append(comparisonOperator);
                            builder.Append('(');

                            ushort countIn = 1;

                            foreach (object value in enumerable)
                            {
                                IParameter parameterIn = CreateParameter(parameterConfig);

                                parameterIn.ParameterName = string.Concat(parameterIn.ParameterName, countIn);

                                if (countIn > 1)
                                {
                                    builder.Append(',');
                                }

                                builder.Append(parameterIn.ParameterName);

                                parameterIn.Value = childRule.Value;
                                parameters.Add(parameterIn);

                                countIn++;
                            }

                            builder.Append(')');
                        }
                        else
                        {
                            builder.Append(parameterConfig.SourceColumnAlias);
                            builder.Append(' ');
                            builder.Append(comparisonOperator);
                            builder.Append(' ');
                            builder.Append(parameterConfig.ParameterName);
                            builder.Append(' ');

                            parameters.Add(CreateParameter(parameterConfig, childRule.Value));
                        }
                    }

                    if (childRule.Rules?.Count > 0)
                    {
                        builder.Append(GetRules(childRule, parameters, searchParameter, false));
                    }
                }
            }

            builder.Append(')');

            return builder.ToString();
        }

        /// <summary>
        /// Gets select command of the entity.
        /// </summary>
        /// <param name="parameterId">Identifier Parameter configuration.</param>
        /// <returns>SQL statement</returns>
        private string GetSelectSqlStatement(ParameterConfig parameterId = null)
        {
            var sqlStatement = $"SELECT * FROM {_view.Name} ";

            if (parameterId is not null)
            {
                sqlStatement += $"WHERE {parameterId.SourceColumnAlias} = {parameterId.ParameterName}";
            }

            return sqlStatement;
        }

        /// <summary>
        /// Search the sql comparison operator.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>Returns the SqlComparisonOperator content.</returns>
        private static string SearchSqlComparisonOperators(IRule<TEntityField> rule)
        {
            return rule.ComparisonOperator switch
            {
                SqlComparisonOperator.EqualTo => "=",
                SqlComparisonOperator.GreaterThan => ">",
                SqlComparisonOperator.LessThan => "<",
                SqlComparisonOperator.GreaterThanOrEqualTo => ">=",
                SqlComparisonOperator.LessThanOrEqualTo => "<=",
                SqlComparisonOperator.NotEqualTo => "<>",
                _ => "In"
            };
        }

        /// <summary>
        /// Search the sql operator.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="action">If SqlOperator is not null then trigger the action.</param>
        private static void SearchSqlOperator(IRule<TEntityField> rule, Action<string> action)
        {
            if (rule.SqlOperator.HasValue)
            {
                var sqlOperator = rule.SqlOperator.Value switch
                {
                    SqlOperator.And => "And",
                    SqlOperator.Or => "Or",
                    _ => "Not"
                };

                action(sqlOperator);
            }
        }

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
