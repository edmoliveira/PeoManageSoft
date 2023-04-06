using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Remove
{
    /// <summary>
    /// Handles all commands to remove the role.
    /// </summary>
    internal sealed class RemoveHandler : IRemoveHandler
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
        /// Remove role command.
        /// </summary>
        private readonly IRemoveCommand _command;
        /// <summary>
        /// Remove resource command. 
        /// </summary>
        private readonly IRemoveResourceCommand _resourceCommand;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Remove.RemoveHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="command">Remove role command.</param>
        /// <param name="resourceCommand">Remove resource command. </param>
        /// <param name="logger">Log</param>
        public RemoveHandler(
                ITransactionScope transactionScope,
                IScopeNoSql scopeNoSql,
                IRemoveCommand command,
                IRemoveResourceCommand resourceCommand,
                ILogger<RemoveHandler> logger
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
        /// Handles the update role command
        /// </summary>
        /// <param name="request">Request for the update role command.</param>
        /// <returns>Represents an asynchronous operation</returns>
        public async Task HandleAsync(RemoveRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _transactionScope
                    .UsingAsync(async scope =>
                    {
                        scope.BeginTransaction();

                        await _command.ExecuteAsync(scope, request).ConfigureAwait(false);

                        await _scopeNoSql.UsingAsync(async rep =>
                        {
                            await _resourceCommand.ExecuteAsync(
                                    rep.Authorization.Role,
                                    new DeleteResourceRequest
                                    {
                                        RoleId = request.Id
                                    }
                            ).ConfigureAwait(false);

                        }).ConfigureAwait(false);
                    })
                    .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
