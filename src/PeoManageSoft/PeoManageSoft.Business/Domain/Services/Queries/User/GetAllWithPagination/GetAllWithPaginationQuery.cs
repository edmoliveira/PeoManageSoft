using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination
{
    /// <summary>
    /// Query to get all users with pagination.
    /// </summary>
    internal sealed class GetAllWithPaginationQuery : IGetAllWithPaginationQuery
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetAllWithPaginationQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination.GetAllWithPaginationQuery class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetAllWithPaginationQuery(
                IUserRepository repository,
                IMapper mapper,
                ILogger<GetAllWithPaginationQuery> logger
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
        public async Task<IEnumerable<GetResponse>> ExecuteAsync(IScope scope, GetAllWithPaginationRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var response = _mapper.Map<IEnumerable<GetResponse>>(
                await _repository.SelectAllWithPaginationAsync(
                    scope, request.Page, request.QuantityPerPage, request.OrderBy
                ).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
