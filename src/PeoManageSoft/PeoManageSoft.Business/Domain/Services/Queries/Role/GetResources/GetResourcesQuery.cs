using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Get resources query.
    /// </summary>
    internal sealed class GetResourcesQuery : IGetResourcesQuery
    {
        #region Fields

        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetResourcesQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources.GetResourcesQuery class.
        /// </summary>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetResourcesQuery(
                IMapper mapper,
                ILogger<GetResourcesQuery> logger
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
        public async Task<IEnumerable<GetResourcesResponse>> ExecuteAsync(IRoleCollection collection, GetResourcesRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResourcesResponse> response = new List<GetResourcesResponse>();

            var documents = await collection.FindAsync(p => p.RoleId == request.RoleId).ConfigureAwait(false);

            if (documents != null)
            {
                response = _mapper.Map<IEnumerable<GetResourcesResponse>>(documents.FirstOrDefault().Resources);
            }

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
