using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Remove;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.Delete
{
    /// <summary>
    /// Delete user application layer.
    /// </summary>
    internal sealed class DeleteApplication : IDeleteApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all commands to remove the user.
        /// </summary>
        private readonly IRemoveHandler _removeHandler;
        /// <summary>
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
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
        private readonly ILogger<DeleteApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Delete.DeleteApplication class.
        /// </summary>
        /// <param name="removeHandler">Handles all commands to remove the user.</param>
        /// <param name="functionFacade">User function facade that provides a simplified interface./param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public DeleteApplication(
                IRemoveHandler removeHandler,
                IUserFunctionFacade functionFacade,
                IMapper mapper,
                IAppConfig appConfig,
                ILogger<DeleteApplication> logger
            )
        {
            _removeHandler = removeHandler;
            _functionFacade = functionFacade;
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
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task HandleAsync(DeleteRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            bool exists = await _functionFacade.ExistsAsync(request.Id).ConfigureAwait(false);

            if (!exists)
            {
                throw new RequestException(HttpStatusCode.NotFound, _appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(request.Id)));
            }

            await _removeHandler.HandleAsync(_mapper.Map<RemoveRequest>(request)).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
