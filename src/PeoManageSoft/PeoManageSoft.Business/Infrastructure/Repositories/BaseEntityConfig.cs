using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;
using System.Text;

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
        /// Gets select by id command of the entity.
        /// </summary>
        /// <param name="view">View object.</param>
        /// <param name="parameterId">Identifier Parameter configuration.</param>
        /// <returns>SQL statement</returns>
        public static string GetSelectByIdSqlStatement(View view, ParameterConfig parameterId)
        {
            return GetSelectSqlStatement(view, parameterId);
        }

        /// <summary>
        /// Gets select all command of the entity.
        /// </summary>
        /// <param name="view">View object.</param>
        /// <returns>SQL statement</returns>
        public static string GetSelectAllSqlStatement(View view)
        {
            return GetSelectSqlStatement(view, null);
        }

        /// <summary>
        /// Gets select by rules command of the entity.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="view">View object.</param>
        /// <param name="rule">Rules to filter the data</param>
        /// <param name="searchParameter">Search for parameter in entity configuration</param>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>SQL statement</returns>
        public static string GetSelectByRulesSqlStatement<TEntityField>(
            IServiceProvider provider,
            View view,
            IRule<TEntityField> rule,
            Func<TEntityField, ParameterConfig> searchParameter,
            out IEnumerable<IParameter> parameters
            )
        {
            var paramList = new List<IParameter>();

            var sqlStatement = GetSelectSqlStatement(view, null);

            sqlStatement += $"WHERE {GetRules(provider, rule, paramList, searchParameter)}";

            parameters = paramList;

            return sqlStatement;
        }

        /// <summary>
        /// Gets update command of the entity.
        /// </summary>
        /// <param name="table">Table object.</param>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>SQL statement</returns>
        public static string GetUpdateSqlStatement(Table table, IEnumerable<IParameter> parameters)
        {
            if (table is null) { throw new ArgumentException($"The Argument '{nameof(table)}' is null"); }
            if (parameters is null) { throw new ArgumentException($"The Argument '{nameof(parameters)}' is null"); }

            IParameter parameterId = parameters.Where(c => c.IsUniqueIdentifier).FirstOrDefault();

            if (parameterId is null) { throw new EntityIdNotFoundException(); }

            return $@"
                UPDATE {table.Name} SET {GetFieldsAndParameters(parameters, false)} 
                WHERE {parameterId.SourceColumn} = {parameterId.ParameterName}
            ";
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
        /// Gets rules to filter the data
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="rule">Rules to filter the data</param>
        /// <param name="parameters">Parameter list to a command object</param>
        /// <param name="searchParameter">Search for parameter in entity configuration</param>
        /// <param name="canSqlOperator">Indicates whether it can put the sql operator.</param>
        /// <returns>Rules Ex: Field1 = '1' or Field2 <> '45'</returns>
        private static string GetRules<TEntityField>(
            IServiceProvider provider,
            IRule<TEntityField> rule,
            IList<IParameter> parameters,
            Func<TEntityField, ParameterConfig> searchParameter,
            bool canSqlOperator = true)
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
                                IParameter parameterIn = CreateParameter(provider, parameterConfig);

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

                            parameters.Add(CreateParameter(provider, parameterConfig, childRule.Value));
                        }
                    }

                    if (childRule.Rules?.Count > 0)
                    {
                        builder.Append(GetRules(provider, childRule, parameters, searchParameter, false));
                    }
                }
            }

            builder.Append(')');

            return builder.ToString();
        }

        /// <summary>
        /// Search the sql comparison operator.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="rule"></param>
        /// <returns>Returns the SqlComparisonOperator content.</returns>
        private static string SearchSqlComparisonOperators<TEntityField>(IRule<TEntityField> rule)
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
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="rule"></param>
        /// <param name="action">If SqlOperator is not null then trigger the action.</param>
        private static void SearchSqlOperator<TEntityField>(IRule<TEntityField> rule, Action<string> action)
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
        /// Gets select command of the entity.
        /// </summary>
        /// <param name="view">View object.</param>
        /// <param name="parameterId">Identifier Parameter configuration.</param>
        /// <returns>SQL statement</returns>
        private static string GetSelectSqlStatement(View view, ParameterConfig parameterId = null)
        {
            if (view is null) { throw new ArgumentException($"The Argument '{nameof(view)}' is null"); }

            var sqlStatement = $"SELECT * FROM {view.Name} ";

            if (parameterId is not null)
            {
                sqlStatement += $"WHERE {parameterId.SourceColumnAlias} = {parameterId.ParameterName}";
            }

            return sqlStatement;
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
