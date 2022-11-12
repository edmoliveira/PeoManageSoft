using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAll
{
    /// <summary>
    /// Handles all queries to get all the title.
    /// </summary>
    internal sealed class GetAllHandler : IGetAllHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get all title query.
        /// </summary>
        private readonly IGetAllQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetAllHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Title.GetAll.GetAllHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="query">Get all title query.</param>
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
        /// Handles the get all title query
        /// </summary>
        /// <param name="request">Request for the get all title query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get all title query.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync()
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResponse> result = await _transactionScope
                                                        .UsingAsync(async scope => await _query.ExecuteAsync(scope))
                                                        .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
