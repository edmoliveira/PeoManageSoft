using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Add
{
    /// <summary>
    /// Add title command.
    /// </summary>
    internal sealed class AddCommand : IAddCommand
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly ITitleRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Title.Add.AddCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public AddCommand(
                ITitleRepository repository,
                IMapper mapper,
                ILogger<AddCommand> logger
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
        /// <param name="request">Request for the add title command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add title command.
        /// </returns>
        public async Task<AddResponse> ExecuteAsync(IScope scope, AddRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            TitleEntity entity = _mapper.Map<TitleEntity>(request);

            await _repository.InsertAsync(scope, entity).ConfigureAwait(false);

            AddResponse response = _mapper.Map<AddResponse>(entity);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
