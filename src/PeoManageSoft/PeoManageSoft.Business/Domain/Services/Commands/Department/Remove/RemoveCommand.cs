using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Remove
{
    /// <summary>
    /// Remove department command.
    /// </summary>
    internal sealed class RemoveCommand : IRemoveCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IDepartmentRepository _repository;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RemoveCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Department.Remove.RemoveCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="logger">Log</param>
        public RemoveCommand(
                IDepartmentRepository repository,
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
        /// <param name="request">Request for the update department command.</param>
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
