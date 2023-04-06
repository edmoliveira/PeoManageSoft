using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Remove;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Role.Delete
{
    /// <summary>
    /// Delete role application layer.
    /// </summary>
    internal sealed class DeleteApplication : IDeleteApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all commands to remove the role.
        /// </summary>
        private readonly IRemoveHandler _removeHandler;
        /// <summary>
        /// Application layer validation object.
        /// </summary>
        private readonly IDeleteValidation _deleteValidation;
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
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.Delete.DeleteApplication class.
        /// </summary>
        /// <param name="removeHandler">Handles all commands to remove the role.</param>
        /// <param name="deleteValidation">Application layer validation object.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public DeleteApplication(
                IRemoveHandler removeHandler,
                IDeleteValidation deleteValidation,
                IMapper mapper,
                IAppConfig appConfig,
                ILogger<DeleteApplication> logger
            )
        {
            _removeHandler = removeHandler;
            _deleteValidation = deleteValidation;
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

            await _deleteValidation.RunValidationAsync(request).ConfigureAwait(false);

            await _removeHandler.HandleAsync(_mapper.Map<RemoveRequest>(request)).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
