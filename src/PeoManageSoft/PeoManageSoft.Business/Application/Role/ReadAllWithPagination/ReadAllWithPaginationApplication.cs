using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.Role.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Role.ReadAllWithPagination
{
    /// <summary>
    /// Read all roles with pagination application layer.
    /// </summary>
    internal sealed class ReadAllWithPaginationApplication : IReadAllWithPaginationApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get all the role with pagination.
        /// </summary>
        private readonly IGetAllWithPaginationHandler _getAllWithPaginationHandler;
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
        private readonly ILogger<ReadAllWithPaginationApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.ReadAllWithPagination.ReadAllWithPaginationApplication class.
        /// </summary>
        /// <param name="getAllWithPaginationHandler">Handles all queries to get all the role with pagination.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ReadAllWithPaginationApplication(
            IGetAllWithPaginationHandler getAllWithPaginationHandler,
            IMapper mapper,
            IAppConfig appConfig,
            ILogger<ReadAllWithPaginationApplication> logger
        )
        {
            _getAllWithPaginationHandler = getAllWithPaginationHandler;
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
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> HandleAsync(ReadAllWithPaginationRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<ReadResponse> response = _mapper.Map<IEnumerable<ReadResponse>>(
                await _getAllWithPaginationHandler.HandleAsync(_mapper.Map<GetAllWithPaginationRequest>(request)).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
