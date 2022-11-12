﻿using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Update
{
    /// <summary>
    /// Handles all commands to update the title.
    /// </summary>
    internal sealed class UpdateHandler : IUpdateHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Update title command.
        /// </summary>
        private readonly IUpdateCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<UpdateHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Title.Update.UpdateHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="command">Update title command.</param>
        /// <param name="logger">Log</param>
        public UpdateHandler(
                ITransactionScope transactionScope,
                IUpdateCommand command,
                ILogger<UpdateHandler> logger
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
        public async Task HandleAsync(UpdateRequest request)
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
