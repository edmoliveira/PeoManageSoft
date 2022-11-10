using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Update;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Application.User.Change
{
    /// <summary>
    /// Change user application layer.
    /// </summary>
    internal sealed class ChangeApplication : IChangeApplication
    {
        #region Fields

        /// <summary>
        /// Application layer validation object.
        /// </summary>
        private readonly IChangeValidation _changeValidation;
        /// <summary>
        ///  Handles all commands to update the user.
        /// </summary>
        private readonly IUpdateHandler _updateHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ChangeApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Change.ChangeApplication class.
        /// </summary>
        /// <param name="changeValidation"> Application layer validation object.</param>
        /// <param name="updateHandler">Handles all commands to update the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public ChangeApplication(
            IChangeValidation changeValidation,
            IUpdateHandler updateHandler,
            IMapper mapper,
            ILogger<ChangeApplication> logger
        )
        {
            _changeValidation = changeValidation;
            _updateHandler = updateHandler;
            _mapper = mapper;
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
        public async Task HandleAsync(ChangeRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _changeValidation.RunValidationAsync(request).ConfigureAwait(false);

            await _updateHandler.HandleAsync(_mapper.Map<UpdateRequest>(request)).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
