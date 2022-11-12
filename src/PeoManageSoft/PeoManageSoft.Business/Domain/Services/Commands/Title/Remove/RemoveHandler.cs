using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Remove
{
    /// <summary>
    /// Handles all commands to remove the title.
    /// </summary>
    internal sealed class RemoveHandler : IRemoveHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Remove title command.
        /// </summary>
        private readonly IRemoveCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Title.Remove.RemoveHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="command">Remove title command.</param>
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
        /// Handles the update title command
        /// </summary>
        /// <param name="request">Request for the update title command.</param>
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
