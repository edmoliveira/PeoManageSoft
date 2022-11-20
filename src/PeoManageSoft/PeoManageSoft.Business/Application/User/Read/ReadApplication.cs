using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.Read
{
    /// <summary>
    /// Read user application layer.
    /// </summary>
    internal sealed class ReadApplication : IReadApplication
    {
        #region Fields

        /// <summary>
        /// Application layer validation object
        /// </summary>
        private readonly IReadValidation _readValidation;
        /// <summary>
        ///  Handles all queries to get the user.
        /// </summary>
        private readonly IGetHandler _getHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Application Configuration.
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ReadApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Read.ReadApplication class.
        /// </summary>
        /// <param name="readValidation">Application layer validation object</param>
        /// <param name="getHandler">Handles all queries to get the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ReadApplication(
            IReadValidation readValidation,
            IGetHandler getHandler,
            IMapper mapper,
            IAppConfig appConfig,
            ILogger<ReadApplication> logger
        )
        {
            _readValidation = readValidation;
            _getHandler = getHandler;
            _mapper = mapper;
            _appConfig = appConfig;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<ReadResponse> HandleAsync(ReadRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _readValidation.RunValidationAsync(request).ConfigureAwait(false);

            ReadResponse response = _mapper.Map<ReadResponse>(
                await _getHandler.HandleAsync(_mapper.Map<GetRequest>(request)).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
