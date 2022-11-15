using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.Department.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetAll;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Application.Department.ReadAll
{
    /// <summary>
    /// Read all department application layer.
    /// </summary>
    internal sealed class ReadAllApplication : IReadAllApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all queries to get all the department.
        /// </summary>
        private readonly IGetAllHandler _getAllHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ReadAllApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.ReadAll.ReadAllApplication class.
        /// </summary>
        /// <param name="getAllHandler">Handles all queries to get all the department.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public ReadAllApplication(
                IGetAllHandler getAllHandler,
                IMapper mapper,
                ILogger<ReadAllApplication> logger
            )
        {
            _getAllHandler = getAllHandler;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> HandleAsync()
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<ReadResponse> response = _mapper.Map<IEnumerable<ReadResponse>>(
                await _getAllHandler.HandleAsync().ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
