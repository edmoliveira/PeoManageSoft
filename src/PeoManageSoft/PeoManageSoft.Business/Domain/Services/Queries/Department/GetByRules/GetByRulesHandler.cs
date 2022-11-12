using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRules
{
    /// <summary>
    /// Handles all queries to get the department by rules.
    /// </summary>
    internal sealed class GetByRulesHandler : BaseGetByRulesHandler<DepartmentEntityField>, IGetByRulesHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get department by rules query.
        /// </summary>
        private readonly IGetByRulesQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByRulesHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesHandler.GetByRulesHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repositoryFactory">Create objects from repositories.</param>
        /// <param name="query">Get department by rules query.</param>
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
        /// Handles the get department by rules query
        /// </summary>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get by rules query.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync(IRule<DepartmentEntityField> rule)
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
