using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;

namespace PeoManageSoft.Business.Domain.Queries.User.GetAll
{
    /// <summary>
    /// Handles all queries to get all the user.
    /// </summary>
    internal class GetAllHandler : IGetAllHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get all user query.
        /// </summary>
        private readonly IGetAllQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetAllHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Queries.User.GetAll.GetAllHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="query">Get all user query.</param>
        /// <param name="logger">Log</param>
        public GetAllHandler(
                ITransactionScope transactionScope,
                IGetAllQuery query,
                ILogger<GetAllHandler> logger
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
        /// Handles the get all user query
        /// </summary>
        /// <param name="request">Request for the get all user query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get all user query.
        /// </returns>
        public async Task<IEnumerable<GetAllResponse>> HandleAsync()
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetAllResponse> result = await _transactionScope
                                                        .UsingAsync(async scope => await _query.ExecuteAsync(scope))
                                                        .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
