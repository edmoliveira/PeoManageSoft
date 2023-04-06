using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Get policies query.
    /// </summary>
    internal sealed class GetPoliciesQuery : IGetPoliciesQuery
    {
        #region Fields

        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetPoliciesQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies.GetPoliciesQuery class.
        /// </summary>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetPoliciesQuery(
                IMapper mapper,
                ILogger<GetPoliciesQuery> logger
            )
        {
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<IEnumerable<GetPoliciesResponse>> ExecuteAsync(IPolicyCollection collection, GetPoliciesRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetPoliciesResponse> response = _mapper.Map<IEnumerable<GetPoliciesResponse>>(
                await collection.FindAsync(p => p.UserId == request.UserId).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
