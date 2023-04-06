using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Security.Claims;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Create token command.
    /// </summary>
    internal sealed class CreateTokenCommand : ICreateTokenCommand
    {
        #region Fields

        /// <summary>
        /// Manages Json Web Token.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<CreateTokenCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken.CreateTokenCommand class.
        /// </summary>
        /// <param name="tokenJwt">Manages Json Web Token.</param>
        /// <param name="logger">Log</param>
        public CreateTokenCommand(
                ITokenJwt tokenJwt,
                ILogger<CreateTokenCommand> logger
            )
        {
            _tokenJwt = tokenJwt;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the add user command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add user command.
        /// </returns>
        public async Task<CreateTokenResponse> ExecuteAsync(CreateTokenRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            DateTime expires = DateTime.UtcNow.AddSeconds(request.ExpireSeconds);

            ClaimsIdentity claimsIdentity = new(LoggedUser.CreateClaims(request.Id, request.Login, request.RoleId));

            string token = await _tokenJwt.CreateTokenAsync(claimsIdentity, expires).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return new CreateTokenResponse { Key = token };
        }

        #endregion

        #endregion
    }
}
