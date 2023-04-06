using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRules
{
    /// <summary>
    /// Handles all queries to get the role by rules.
    /// </summary>
    internal sealed class GetByRulesHandler : BaseGetByRulesHandler<RoleEntityField>, IGetByRulesHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get role by rules query.
        /// </summary>
        private readonly IGetByRulesQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByRulesHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRulesHandler.GetByRulesHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repositoryFactory">Create objects from repositories.</param>
        /// <param name="query">Get role by rules query.</param>
        /// <param name="logger">Log</param>
        public GetByRulesHandler(
                ITransactionScope transactionScope,
                IRepositoryFactory repositoryFactory,
                IGetByRulesQuery query,
                ILogger<GetByRulesHandler> logger
            ) : base(repositoryFactory)
        {
            _transactionScope = transactionScope;
            _query = query;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the get role by rules query
        /// </summary>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get by rules query.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync(IRule<RoleEntityField> rule)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResponse> result = await _transactionScope
                                                .UsingAsync(async scope => await _query.ExecuteAsync(scope, rule))
                                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
