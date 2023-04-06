using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Handles all commands to add the role.
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
        /// Add role command.
        /// </summary>
        private readonly IAddCommand _command;
        /// <summary>
        /// Add resource command.
        /// </summary>
        private readonly IAddResourceCommand _resourceCommand;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Add.AddHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="scopeNoSql">Makes a code block. </param>
        /// <param name="command">Add role command.</param>
        /// <param name="resourceCommand">Add resource command.</param>
        /// <param name="logger">Log</param>
        public AddHandler(
                ITransactionScope transactionScope,
                IScopeNoSql scopeNoSql,
                IAddCommand command,
                IAddResourceCommand resourceCommand,
                ILogger<AddHandler> logger
            )
        {
            _transactionScope = transactionScope;
            _scopeNoSql = scopeNoSql;
            _command = command;
            _resourceCommand = resourceCommand;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the add role command
        /// </summary>
        /// <param name="request">Request for the add role command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add role command.
        /// </returns>
        public async Task<AddResponse> HandleAsync(AddRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddResponse result = await _transactionScope
                                        .UsingAsync(async scope =>
                                        {
                                            scope.BeginTransaction();

                                            var response = await _command.ExecuteAsync(scope, request).ConfigureAwait(false);

                                            await _scopeNoSql.UsingAsync(async rep =>
                                            {
                                                await _resourceCommand.ExecuteAsync(
                                                        rep.Authorization.Role,
                                                        new AddResourceRequest
                                                        {
                                                            RoleId = response.NewId,
                                                            Resources = request.Resources
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
