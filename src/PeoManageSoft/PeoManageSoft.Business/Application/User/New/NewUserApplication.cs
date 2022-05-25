using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Commands.User.Add;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// New user application layer.
    /// </summary>
    internal class NewUserApplication : INewUserApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all commands to add the user.
        /// </summary>
        private readonly IAddHandler _addHandler;
        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<NewUserApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewUserApplication class.
        /// </summary>
        /// <param name="addHandler">Handles all commands to add the user.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public NewUserApplication(
                IAddHandler addHandler,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<NewUserApplication> logger
            )
        {
            _addHandler = addHandler;
            _appConfig = appConfig;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer of the new user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<NewUserResponse> HandleAsync(NewUserRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddRequest commandRequest = _mapper.Map<AddRequest>(request);

            commandRequest.Password = Cryptography.Encrypt(request.Password, _appConfig.AuthTokenSecrect);

            AddResponse commandResponse = await _addHandler.HandleAsync(commandRequest).ConfigureAwait(false);

            NewUserResponse response = _mapper.Map<NewUserResponse>(commandResponse);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
