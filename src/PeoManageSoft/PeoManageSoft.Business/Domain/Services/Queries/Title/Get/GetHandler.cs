using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.Get
{
    /// <summary>
    /// Handles all queries to get the title.
    /// </summary>
    internal sealed class GetHandler : IGetHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get title query.
        /// </summary>
        private readonly IGetQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Title.Get.GetHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="query">Get title query.</param>
        /// <param name="logger">Log</param>
        public GetHandler(
                ITransactionScope transactionScope,
                IGetQuery query,
                ILogger<GetHandler> logger
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
        /// Handles the get title query
        /// </summary>
        /// <param name="request">Request for the get title query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get title query.
        /// </returns>
        public async Task<GetResponse> HandleAsync(GetRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            GetResponse result = await _transactionScope
                                            .UsingAsync(async scope => await _query.ExecuteAsync(scope, request))
                                            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
