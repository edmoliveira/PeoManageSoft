using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Patch
{
    /// <summary>
    /// Handles all commands to patch the department.
    /// </summary>
    internal sealed class PatchHandler : IPatchHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Patch department command.
        /// </summary>
        private readonly IPatchCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<PatchHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Department.Patch.PatchHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="command">Patch department command.</param>
        /// <param name="logger">Log</param>
        public PatchHandler(
                ITransactionScope transactionScope,
                IPatchCommand command,
                ILogger<PatchHandler> logger
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
        /// Handles the patch department command
        /// </summary>
        /// <param name="request">Request for the patch department command.</param>
        /// <returns>Represents an asynchronous operation</returns>
        public async Task HandleAsync(PatchRequest request)
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

