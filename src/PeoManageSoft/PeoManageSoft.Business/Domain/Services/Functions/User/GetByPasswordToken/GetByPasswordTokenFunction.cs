using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.GetByPasswordToken
{
    /// <summary>
    /// Function to get the user by passwordToken
    /// </summary>
    internal sealed class GetByPasswordTokenFunction : IGetByPasswordTokenFunction
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get the user by rules.
        /// </summary>
        private readonly IGetByRulesHandler _getByRulesHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetByPasswordTokenFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.GetByPasswordToken.GetByPasswordTokenFunction class.
        /// </summary>
        /// <param name="getByRulesHandler">Handles all queries to get the user by rules.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetByPasswordTokenFunction(
                IGetByRulesHandler getByRulesHandler,
                IMapper mapper,
                ILogger<GetByPasswordTokenFunction> logger
            )
        {
            _getByRulesHandler = getByRulesHandler;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<GetResponse> ExecuteAsync(string passwordToken)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var rules = new IRule<UserEntityField>[1]
                            {
                    _getByRulesHandler.CreateRule(UserEntityField.PasswordToken, SqlComparisonOperator.EqualTo, passwordToken)
                            };

            var response = await _getByRulesHandler.HandleAsync(_getByRulesHandler.CreateRule(rules)).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return response.FirstOrDefault();
        }

        #endregion

        #endregion
    }
}
