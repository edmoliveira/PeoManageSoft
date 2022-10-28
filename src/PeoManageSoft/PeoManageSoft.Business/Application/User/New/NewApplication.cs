using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// New user application layer.
    /// </summary>
    internal class NewApplication : INewApplication
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
        private readonly ILogger<NewApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewApplication class.
        /// </summary>
        /// <param name="addHandler">Handles all commands to add the user.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public NewApplication(
                IAddHandler addHandler,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<NewApplication> logger
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
        public async Task<NewResponse> HandleAsync(NewRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddRequest commandRequest = _mapper.Map<AddRequest>(request);

            commandRequest.Password = Cryptography.Encrypt(request.Password, _appConfig.AuthTokenSecrect);

            NewResponse response = _mapper.Map<NewResponse>(
                await _addHandler.HandleAsync(commandRequest).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
