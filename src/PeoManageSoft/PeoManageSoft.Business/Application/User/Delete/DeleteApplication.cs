using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Domain.Commands.User.Remove;
using PeoManageSoft.Business.Domain.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Application.User.Delete
{
    /// <summary>
    /// Delete user application layer.
    /// </summary>
    internal class DeleteApplication : IDeleteApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all commands to remove the user.
        /// </summary>
        private readonly IRemoveHandler _removeHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
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
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public DeleteApplication(
                IRemoveHandler removeHandler,
                IMapper mapper,
                ILogger<DeleteApplication> logger
            )
        {
            _removeHandler = removeHandler;
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
        public async Task HandleAsync(DeleteRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _removeHandler.HandleAsync(_mapper.Map<RemoveRequest>(request)).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
