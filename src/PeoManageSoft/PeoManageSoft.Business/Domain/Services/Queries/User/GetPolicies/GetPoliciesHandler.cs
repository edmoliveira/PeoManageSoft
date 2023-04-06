using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Handles all queries to get the user policies.
    /// </summary>
    internal sealed class GetPoliciesHandler : IGetPoliciesHandler
    {
        #region Fields

        /// <summary>
        /// Makes a code block. 
        /// </summary>
        private readonly IScopeNoSql _scopeNoSql;
        /// <summary>
        /// Get policies query.
        /// </summary>
        private readonly IGetPoliciesQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetPoliciesHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies.GetPoliciesHandler class.
        /// </summary>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="query">Get policies query.</param>
        /// <param name="logger">Log</param>
        public GetPoliciesHandler(
                IScopeNoSql scopeNoSql,
                IGetPoliciesQuery query,
                ILogger<GetPoliciesHandler> logger
            )
        {
            _scopeNoSql = scopeNoSql;
            _query = query;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the get policies query
        /// </summary>
        /// <param name="request">Request for the get policies query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get user query.
        /// </returns>
        public async Task<IEnumerable<GetPoliciesResponse>> HandleAsync(GetPoliciesRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetPoliciesResponse> result = await _scopeNoSql
                                                .UsingAsync(async rep => await _query.ExecuteAsync(rep.Authorization.Policy, request))
                                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
