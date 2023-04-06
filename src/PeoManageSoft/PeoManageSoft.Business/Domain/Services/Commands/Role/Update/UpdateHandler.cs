using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Handles all commands to update the role.
    /// </summary>
    internal sealed class UpdateHandler : IUpdateHandler
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
        /// Update role command.
        /// </summary>
        private readonly IUpdateCommand _command;
        /// <summary>
        /// Update resource command. 
        /// </summary>
        private readonly IUpdateResourceCommand _resourceCommand;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<UpdateHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Update.UpdateHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="command">Update role command.</param>
        /// <param name="resourceCommand">Update resource command.</param>
        /// <param name="logger">Log</param>
        public UpdateHandler(
                ITransactionScope transactionScope,
                IScopeNoSql scopeNoSql,
                IUpdateCommand command,
                IUpdateResourceCommand resourceCommand,
                ILogger<UpdateHandler> logger
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
        public async Task HandleAsync(UpdateRequest request)
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
                                    new UpdateResourceRequest
                                    {
                                        RoleId = request.Id,
                                        Resources = request.Resources
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
