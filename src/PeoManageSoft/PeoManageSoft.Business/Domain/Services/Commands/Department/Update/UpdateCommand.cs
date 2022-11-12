using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Update
{
    /// <summary>
    /// Update department command.
    /// </summary>
    internal sealed class UpdateCommand : IUpdateCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IDepartmentRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<UpdateCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Department.Update.UpdateCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public UpdateCommand(
                IDepartmentRepository repository,
                IMapper mapper,
                ILogger<UpdateCommand> logger
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
        /// <param name="request">Request for the update department command.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(IScope scope, UpdateRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            DepartmentEntity entity = _mapper.Map<DepartmentEntity>(request);

            await _repository.UpdateAsync(scope, entity).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
