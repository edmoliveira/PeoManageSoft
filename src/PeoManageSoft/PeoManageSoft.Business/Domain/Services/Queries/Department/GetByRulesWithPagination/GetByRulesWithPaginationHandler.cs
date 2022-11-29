﻿using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination
{
    /// <summary>
    /// Handles all queries to get departments by rules with pagination.
    /// </summary>
    internal sealed class GetByRulesWithPaginationHandler : BaseGetByRulesHandler<DepartmentEntityField>, IGetByRulesWithPaginationHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Query to get departments by rules with pagination.
        /// </summary>
        private readonly IGetByRulesWithPaginationQuery _query;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByRulesWithPaginationHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination.GetByRulesWithPaginationHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repositoryFactory">Create objects from repositories.</param>
        /// <param name="query">Query to get departments by rules with pagination..</param>
        /// <param name="logger">Log</param>
        public GetByRulesWithPaginationHandler(
                ITransactionScope transactionScope,
                IRepositoryFactory repositoryFactory,
                IGetByRulesWithPaginationQuery query,
                ILogger<GetByRulesWithPaginationHandler> logger
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
        /// Handles the query to get departments by rules with pagination and asynchronously using Task. 
        /// </summary>
        /// <param name="request">Request for the query to get departments by rules with pagination.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the to get departments by rules with pagination.
        /// </returns>
        public async Task<IEnumerable<GetResponse>> HandleAsync(GetByRulesWithPaginationRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<GetResponse> result = await _transactionScope
                                                .UsingAsync(async scope => await _query.ExecuteAsync(scope, request))
                                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
