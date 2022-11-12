using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRules
{
    /// <summary>
    /// Handles all queries to get the title by rules.
    /// </summary>
    internal sealed class GetByRulesHandler : BaseGetByRulesHandler<TitleEntityField>, IGetByRulesHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Get title by rules query.
        /// </summary>
        private readonly IGetByRulesQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByRulesHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRulesHandler.GetByRulesHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repositoryFactory">Create objects from repositories.</param>
        /// <param name="query">Get title by rules query.</param>
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
        /// Handles the get title by rules query
        /// </summary>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the get by rules query.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync(IRule<TitleEntityField> rule)
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
