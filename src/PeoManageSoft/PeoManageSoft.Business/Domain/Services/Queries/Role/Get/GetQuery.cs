using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.Get
{
    /// <summary>
    /// Get role query.
    /// </summary>
    internal sealed class GetQuery : IGetQuery
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IRoleRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Role.Get.GetQuery class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetQuery(
                IRoleRepository repository,
                IMapper mapper,
                ILogger<GetQuery> logger
            )
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<GetResponse> ExecuteAsync(IScope scope, GetRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            GetResponse response = _mapper.Map<GetResponse>(
                await _repository.SelectByIdAsync(scope, request.Id).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
