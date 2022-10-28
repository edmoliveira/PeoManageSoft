using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.Response;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using static PeoManageSoft.Business.Infrastructure.Repositories.User.UserEntityConfig;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Get user by authentication query.
    /// </summary>
    internal class GetByAuthenticationQuery : IGetByAuthenticationQuery
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Create objects from repositories
        /// </summary>
        private readonly IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByAuthenticationQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.GetByAuthenticationQuery class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="repositoryFactory">Create objects from repositories</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetByAuthenticationQuery(
                IUserRepository repository,
                IRepositoryFactory repositoryFactory,
                IMapper mapper,
                ILogger<GetByAuthenticationQuery> logger
            )
        {
            _repository = repository;
            _repositoryFactory = repositoryFactory;
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
        public async Task<GetByAuthenticationResponse> ExecuteAsync(IScope scope, GetByAuthenticationRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var rules = new IRule<EntityField>[2]
                {
                    _repositoryFactory.CreateRule(EntityField.Login_Readonly, SqlComparisonOperator.EqualTo, request.Login),
                    _repositoryFactory.CreateRule(EntityField.Password, SqlComparisonOperator.EqualTo, request.Password, SqlOperator.And)
                };

            GetByAuthenticationResponse response = _mapper.Map<GetByAuthenticationResponse>(
                await _repository.SelectByRulesAsync(scope, _repositoryFactory.CreateRule(rules)).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
