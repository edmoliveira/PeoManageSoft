using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Net;

namespace PeoManageSoft.Business.Domain.Commands.User.Remove
{
    /// <summary>
    /// Remove user command.
    /// </summary>
    internal class RemoveCommand : IRemoveCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Commands.User.Remove.RemoveCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="logger">Log</param>
        public RemoveCommand(
                IUserRepository repository,
                ILogger<RemoveHandler> logger
            )
        {
            _repository = repository;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request for the update user command.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(IScope scope, RemoveRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            bool exists = await _repository.ExistsAsync(scope, request.Id).ConfigureAwait(false);

            if (!exists)
            {
                throw new RequestException(HttpStatusCode.NotFound, "User not found!");
            }

            await _repository.DeleteAsync(scope, request.Id).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
