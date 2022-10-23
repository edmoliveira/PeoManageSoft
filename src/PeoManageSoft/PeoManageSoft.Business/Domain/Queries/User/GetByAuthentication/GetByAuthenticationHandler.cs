using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Handles all queries to get the user by authentication.
    /// </summary>
    internal class GetByAuthenticationHandler : IGetByAuthenticationHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get user by authentication query.
        /// </summary>
        private readonly IGetByAuthenticationQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByAuthenticationHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication.GetByAuthenticationHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="query">Get user by authentication query.</param>
        /// <param name="logger">Log</param>
        public GetByAuthenticationHandler(
                ITransactionScope transactionScope,
                IGetByAuthenticationQuery query,
                ILogger<GetByAuthenticationHandler> logger
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
        /// Handles the get user by authentication query
        /// </summary>
        /// <param name="request">Request for the get user by authentication query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get user query.
        /// </returns>
        public async Task<GetByAuthenticationResponse> HandleAsync(GetByAuthenticationRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            GetByAuthenticationResponse result = await _transactionScope
                                                    .UsingAsync(async scope => await _query.ExecuteAsync(scope, request))
                                                    .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
