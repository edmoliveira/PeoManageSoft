using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Net;

namespace PeoManageSoft.Business.Application.User.CreateNewPassword
{
    /// <summary>
    /// Application layer to create new password if the user token is valid. 
    /// </summary>
    internal sealed class CreateNewPasswordApplication : ICreateNewPasswordApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get the user.
        /// </summary>
        private readonly IGetHandler _getHandler;
        /// <summary>
        /// Handles all commands to patch the user.
        /// </summary>
        private readonly IPatchHandler _patchHandler;
        /// <summary>
        /// Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<CreateNewPasswordApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.CreateNewPassword.CreateNewPasswordApplication class.
        /// </summary>
        /// <param name="getHandler">Handles all queries to get the user.</param>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="logger">Log</param>
        public CreateNewPasswordApplication(
                IGetHandler getHandler,
                IPatchHandler patchHandler,
                ITokenJwt tokenJwt,
                ILogger<CreateNewPasswordApplication> logger
            )
        {
            _getHandler = getHandler;
            _patchHandler = patchHandler;
            _tokenJwt = tokenJwt;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task HandleAsync(CreateNewPasswordRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            if (_tokenJwt.TryGetUserIdByUserToken(request.UserToken, out var userId))
            {
                var userResponse = await _getHandler.HandleAsync(new GetRequest
                {
                    Id = userId
                }).ConfigureAwait(false);

                if (userResponse is null)
                {
                    throw new RequestException(HttpStatusCode.NotFound, "User not found!");
                }

                var password = _tokenJwt.EncryptPassword(request.Password);

                await _patchHandler.HandleAsync(new PatchRequest
                {
                    Id = userResponse.Id,
                    Fields = new List<Field<UserEntityField>>
                    {
                        new Field<UserEntityField> {
                            Type = UserEntityField.Password,
                            Value = password
                        }
                    }
                }).ConfigureAwait(false);
            }
            else
            {
                throw new RequestException(HttpStatusCode.Unauthorized, "Expired token!");
            }

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
