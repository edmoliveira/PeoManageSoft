using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Handles all queries to get the role resources.
    /// </summary>
    internal sealed class GetResourcesHandler : IGetResourcesHandler
    {
        #region Fields

        /// <summary>
        /// Makes a code block. 
        /// </summary>
        private readonly IScopeNoSql _scopeNoSql;
        /// <summary>
        /// Get resources query.
        /// </summary>
        private readonly IGetResourcesQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetResourcesHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources.GetResourcesHandler class.
        /// </summary>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="query">Get resources query.</param>
        /// <param name="logger">Log</param>
        public GetResourcesHandler(
                IScopeNoSql scopeNoSql,
                IGetResourcesQuery query,
                ILogger<GetResourcesHandler> logger
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
        /// Handles the get resources query
        /// </summary>
        /// <param name="request">Request for the get resources query.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get user query.
        /// </returns>
        public async Task<IEnumerable<GetResourcesResponse>> HandleAsync(GetResourcesRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResourcesResponse> result = await _scopeNoSql
                                                .UsingAsync(async rep => await _query.ExecuteAsync(rep.Authorization.Role, request))
                                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
