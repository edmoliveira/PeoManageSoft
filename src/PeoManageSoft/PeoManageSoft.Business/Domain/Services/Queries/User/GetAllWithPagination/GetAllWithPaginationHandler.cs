using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the user with paginationg.
    /// </summary>
    internal sealed class GetAllWithPaginationHandler : IGetAllWithPaginationHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Query to get all users with pagination.
        /// </summary>
        private readonly IGetAllWithPaginationQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetAllWithPaginationHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination.GetAllWithPaginationgHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="query">Query to get all users with pagination.</param>
        /// <param name="logger">Log</param>
        public GetAllWithPaginationHandler(
                ITransactionScope transactionScope,
                IGetAllWithPaginationQuery query,
                ILogger<GetAllWithPaginationHandler> logger
            )
        {
            _transactionScope = transactionScope;
            _query = query;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the query to get all users with pagination.
        /// </summary>
        /// <param name="request">Request for the query to get all users with pagination..</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the query to get all users with pagination.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync(GetAllWithPaginationRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var result = await _transactionScope
                                    .UsingAsync(async scope => await _query.ExecuteAsync(scope, request))
                                    .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
