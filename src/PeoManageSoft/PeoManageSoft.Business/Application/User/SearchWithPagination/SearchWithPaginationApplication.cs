using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRulesWithPagination;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using static PeoManageSoft.Business.Application.User.UserEnumerators;

namespace PeoManageSoft.Business.Application.User.SearchWithPagination
{
    /// <summary>
    /// Search users with pagination application layer.
    /// </summary>
    internal sealed class SearchWithPaginationApplication : ISearchWithPaginationApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get users by rules with pagination.
        /// </summary>
        private readonly IGetByRulesWithPaginationHandler _getByRulesWithPaginationHandler;
        /// <summary>
        /// Handles all queries to get all the user with pagination.
        /// </summary>
        private readonly IGetAllWithPaginationHandler _getAllWithPaginationHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Application Configuration.
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SearchWithPaginationApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SearchWithPagination.SearchWithPaginationApplication class.
        /// </summary>
        /// <param name="getByRulesWithPaginationHandler">Handles all queries to get users by rules with pagination.</param>
        /// <param name="getAllWithPaginationHandler">Handles all queries to get all the user with pagination.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public SearchWithPaginationApplication(
            IGetByRulesWithPaginationHandler getByRulesWithPaginationHandler,
            IGetAllWithPaginationHandler getAllWithPaginationHandler,
            IMapper mapper,
            IAppConfig appConfig,
            ILogger<SearchWithPaginationApplication> logger
        )
        {
            _getByRulesWithPaginationHandler = getByRulesWithPaginationHandler;
            _getAllWithPaginationHandler = getAllWithPaginationHandler;
            _mapper = mapper;
            _appConfig = appConfig;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> HandleAsync(SearchWithPaginationRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<ReadResponse> response = _mapper.Map<IEnumerable<ReadResponse>>(
                !string.IsNullOrWhiteSpace(request.SearchFieldValue) ?
                    await GetByRulesWithPaginationAsync(request).ConfigureAwait(false) :
                    await GetAllWithPaginationAsync(request).ConfigureAwait(false)
            );

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #region private

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Returns all users.</returns>
        private async Task<IEnumerable<GetResponse>> GetAllWithPaginationAsync(SearchWithPaginationRequest request)
        {
            return await _getAllWithPaginationHandler.HandleAsync(new GetAllWithPaginationRequest
            {
                Page = request.Page,
                QuantityPerPage = request.QuantityPerPage,
                OrderBy = new OrderBy<UserEntityField>(request.OrderByFields.Select(f => UserEnumerators.ToEntityField(f)), request.OrderByIsDesc)
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all users according to the rules
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Returns all users according to the filter</returns>
        private async Task<IEnumerable<GetResponse>> GetByRulesWithPaginationAsync(SearchWithPaginationRequest request)
        {
            return await _getByRulesWithPaginationHandler.HandleAsync(new GetByRulesWithPaginationRequest
            {
                Page = request.Page,
                QuantityPerPage = request.QuantityPerPage,
                OrderBy = new OrderBy<UserEntityField>(request.OrderByFields.Select(f => UserEnumerators.ToEntityField(f)), request.OrderByIsDesc),
                Rule = _getByRulesWithPaginationHandler.CreateRule(
                    new IRule<UserEntityField>[1]
                    {
                        CreateRule(request.SearchField, request.SearchFieldValue)
                    }
                )
            }).ConfigureAwait(false);
        }

        /// <summary>
        ///  Create a rule to filter the data.
        /// </summary>
        /// <param name="searchField">Search field</param>
        /// <param name="searchFieldValue">Search field value</param>
        /// <returns>Returns the rule object.</returns>
        private IRule<UserEntityField> CreateRule(Fields searchField, object searchFieldValue)
        {
            IRule<UserEntityField> create(UserEntityField field,
                                            SqlComparisonOperator comparisonOperator,
                                            object value)
            {
                return _getByRulesWithPaginationHandler.CreateRule(field, comparisonOperator, value);
            }

            return searchField switch
            {
                Fields.Id => create(UserEntityField.Id_Readonly, SqlComparisonOperator.EqualTo, SafeConvert.ToLong(searchFieldValue)),
                Fields.IsActive => create(UserEntityField.IsActive, SqlComparisonOperator.EqualTo, SafeConvert.ToBoolean(searchFieldValue)),
                Fields.Login => create(UserEntityField.Login_Readonly, SqlComparisonOperator.Like, searchFieldValue),
                Fields.Role => create(UserEntityField.Role, SqlComparisonOperator.EqualTo, searchFieldValue),
                Fields.Name => create(UserEntityField.Name, SqlComparisonOperator.Like, searchFieldValue),
                Fields.ShortName => create(UserEntityField.ShortName, SqlComparisonOperator.Like, searchFieldValue),
                Fields.TitleId => create(UserEntityField.TitleId, SqlComparisonOperator.EqualTo, SafeConvert.ToLong(searchFieldValue)),
                Fields.DepartmentId => create(UserEntityField.DepartmentId, SqlComparisonOperator.EqualTo, SafeConvert.ToLong(searchFieldValue)),
                Fields.Email => create(UserEntityField.Email, SqlComparisonOperator.Like, searchFieldValue),
                Fields.BussinessPhone => create(UserEntityField.BussinessPhone, SqlComparisonOperator.Like, searchFieldValue),
                Fields.MobilePhone => create(UserEntityField.MobilePhone, SqlComparisonOperator.Like, searchFieldValue),
                _ => create(UserEntityField.Location, SqlComparisonOperator.Like, searchFieldValue)
            };
        }

        #endregion

        #endregion
    }
}
