﻿using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Add
{
    /// <summary>
    /// Handles all commands to add the department.
    /// </summary>
    internal sealed class AddHandler : IAddHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Add department command.
        /// </summary>
        private readonly IAddCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Department.Add.AddHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="command">Add department command.</param>
        /// <param name="logger">Log</param>
        public AddHandler(
                ITransactionScope transactionScope,
                IAddCommand command,
                ILogger<AddHandler> logger
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
        /// Handles the add department command
        /// </summary>
        /// <param name="request">Request for the add department command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add department command.
        /// </returns>
        public async Task<AddResponse> HandleAsync(AddRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddResponse result = await _transactionScope
                                            .UsingAsync(async scope => await _command.ExecuteAsync(scope, request))
                                            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
