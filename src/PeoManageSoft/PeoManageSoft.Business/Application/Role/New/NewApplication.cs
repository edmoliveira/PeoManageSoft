using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Application.Role.New
{
    /// <summary>
    /// New role application layer.
    /// </summary>
    internal sealed class NewApplication : INewApplication
    {
        #region Fields

        /// <summary>
        /// Application layer validation object.
        /// </summary>
        private readonly INewValidation _newValidation;
        /// <summary>
        ///  Handles all commands to add the role.
        /// </summary>
        private readonly IAddHandler _addHandler;
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
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.New.NewApplication class.
        /// </summary>
        /// <param name="newValidation">Application layer validation object.</param>
        /// <param name="addHandler">Handles all commands to add the role.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public NewApplication(
                INewValidation newValidation,
                IAddHandler addHandler,
                IMapper mapper,
                ILogger<NewApplication> logger
            )
        {
            _newValidation = newValidation;
            _addHandler = addHandler;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer of the new role and asynchronously using Task.
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

            await _newValidation.RunValidationAsync(request).ConfigureAwait(false);

            AddRequest commandRequest = _mapper.Map<AddRequest>(request);

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
