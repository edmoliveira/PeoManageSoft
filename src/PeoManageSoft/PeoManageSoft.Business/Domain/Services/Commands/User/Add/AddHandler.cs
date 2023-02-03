using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Handles all commands to add the user.
    /// </summary>
    internal sealed class AddHandler : IAddHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Makes a code block. 
        /// </summary>
        private readonly IScopeNoSql _scopeNoSql;
        /// <summary>
        /// Add user command.
        /// </summary>
        private readonly IAddCommand _command;
        /// <summary>
        /// Add policy command.
        /// </summary>
        private readonly IAddPolicyCommand _policyCommand;
        /// <summary>
        /// Add schema command.
        /// </summary>
        private readonly IAddSchemaCommand _schemaCommand;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Add.AddHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="command">Add user command.</param>
        /// <param name="policyCommand">Add policy command.</param>
        /// <param name="logger">Log</param>
        public AddHandler(
                ITransactionScope transactionScope,
                IScopeNoSql scopeNoSql,
                IAddCommand command,
                IAddPolicyCommand policyCommand,
                IAddSchemaCommand schemaCommand,
                ILogger<AddHandler> logger
            )
        {
            _transactionScope = transactionScope;
            _scopeNoSql = scopeNoSql;
            _command = command;
            _policyCommand = policyCommand;
            _schemaCommand = schemaCommand;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the add user command
        /// </summary>
        /// <param name="request">Request for the add user command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add user command.
        /// </returns>
        public async Task<AddResponse> HandleAsync(AddRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddResponse result = await _transactionScope
                                            .UsingAsync(async scope => {
                                                scope.BeginTransaction();

                                                var response = await _command.ExecuteAsync(scope, request).ConfigureAwait(false);

                                                await _scopeNoSql.UsingAsync(async rep =>
                                                {
                                                    await _policyCommand.ExecuteAsync(
                                                            rep.Authorization.Policy,
                                                            new AddPolicyRequest
                                                            {
                                                                UserId = response.NewId,
                                                                Policies = request.Policies
                                                            }
                                                    ).ConfigureAwait(false);

                                                    await _schemaCommand.ExecuteAsync(
                                                            rep.Authorization.Schema,
                                                            new AddSchemaRequest
                                                            {
                                                                UserId = response.NewId,
                                                                Resources = request.SchemaResources
                                                            }
                                                    ).ConfigureAwait(false);

                                                }).ConfigureAwait(false); 

                                                return response;
                                            })
                                            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
