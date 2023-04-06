using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Remove
{
    /// <summary>
    /// Remove role command.
    /// </summary>
    internal sealed class RemoveCommand : IRemoveCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IRoleRepository _repository;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Remove.RemoveCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="logger">Log</param>
        public RemoveCommand(
                IRoleRepository repository,
                ILogger<RemoveCommand> logger
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
        /// <param name="request">Request for the update role command.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(IScope scope, RemoveRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await _repository.DeleteAsync(scope, request.Id).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
