using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.Read
{
    /// <summary>
    /// Read user application layer.
    /// </summary>
    internal sealed class ReadApplication : IReadApplication
    {
        #region Fields

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
        /// <param name="getHandler">Handles all queries to get the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ReadApplication(
                IGetHandler getHandler,
                IMapper mapper,
                IAppConfig appConfig,
                ILogger<ReadApplication> logger
            )
        {
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

            ReadResponse response = _mapper.Map<ReadResponse>(
                await _getHandler.HandleAsync(_mapper.Map<GetRequest>(request)).ConfigureAwait(false)
            );

            if (response == null)
            {
                throw new RequestException(HttpStatusCode.NotFound, _appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(request.Id)));
            }

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
