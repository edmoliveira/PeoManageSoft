using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Commands.User.Remove
{
    /// <summary>
    /// Handles all commands to remove the user.
    /// </summary>
    internal class RemoveHandler : IRemoveHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Remove user command.
        /// </summary>
        private readonly IRemoveCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Commands.User.Remove.RemoveHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="command">Remove user command.</param>
        /// <param name="logger">Log</param>
        public RemoveHandler(
                ITransactionScope transactionScope,
                IRemoveCommand command,
                ILogger<RemoveHandler> logger
            )
        {
            _transactionScope = transactionScope;
            _command = command;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the update user command
        /// </summary>
        /// <param name="request">Request for the update user command.</param>
        /// <returns>Represents an asynchronous operation</returns>
        public async Task HandleAsync(RemoveRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _transactionScope
                    .UsingAsync(async scope => await _command.ExecuteAsync(scope, request))
                    .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
