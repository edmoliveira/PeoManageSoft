using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Domain.Commands.User.CreateToken
{
    /// <summary>
    /// Handles all commands to create token.
    /// </summary>
    internal class CreateTokenHandler : ICreateTokenHandler
    {
        #region Fields

        /// <summary>
        /// Create token command.
        /// </summary>
        private readonly ICreateTokenCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<CreateTokenHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Commands.User.CreateToken.CreateTokenHandler class.
        /// </summary>
        /// <param name="command">Create token command.</param>
        /// <param name="logger">Log</param>
        public CreateTokenHandler(
                ICreateTokenCommand command,
                ILogger<CreateTokenHandler> logger
            )
        {
            _command = command;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the create token command
        /// </summary>
        /// <param name="request">Request for the create token command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add user command.
        /// </returns>
        public async Task<CreateTokenResponse> HandleAsync(CreateTokenRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            CreateTokenResponse result = await _command.ExecuteAsync(request).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
