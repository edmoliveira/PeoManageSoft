using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination
{
    /// <summary>
    /// Query to get departments by rules with pagination.
    /// </summary>
    internal sealed class GetByRulesWithPaginationQuery : IGetByRulesWithPaginationQuery
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IDepartmentRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByRulesWithPaginationQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination.GetByRulesWithPaginationQuery class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetByRulesWithPaginationQuery(
                IDepartmentRepository repository,
                IMapper mapper,
                ILogger<GetByRulesWithPaginationQuery> logger
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
        /// The return IEnumerable[]
        /// </returns>
        public async Task<IEnumerable<GetResponse>> ExecuteAsync(IScope scope, GetByRulesWithPaginationRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResponse> response = _mapper.Map<IEnumerable<GetResponse>>(
                await _repository.SelectByRulesWithPaginationAsync(
                    scope, 
                    request.Page, 
                    request.QuantityPerPage, 
                    request.OrderBy,
                    request.Rule
                ).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
