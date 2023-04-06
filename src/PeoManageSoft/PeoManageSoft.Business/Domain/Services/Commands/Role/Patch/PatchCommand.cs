using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Patch
{
    /// <summary>
    /// Patch role command.
    /// </summary>
    internal sealed class PatchCommand : IPatchCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IRoleRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<PatchCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Patch.PatchCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public PatchCommand(
                IRoleRepository repository,
                IMapper mapper,
                ILogger<PatchCommand> logger
            )
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request for the patch role command.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(IScope scope, PatchRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await _repository.PatchAsync(scope, request.Fields, request.Id).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}

