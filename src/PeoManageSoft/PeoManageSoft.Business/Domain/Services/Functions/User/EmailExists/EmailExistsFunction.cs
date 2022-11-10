using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists
{
    /// <summary>
    /// Function that determines if the email already exists in the user table.
    /// </summary>
    internal sealed class EmailExistsFunction : IEmailExistsFunction
    {
        #region Fields

        /// <summary>
        /// Create objects from repositories
        /// </summary>
        private readonly IRepositoryFactory _repositoryFactory;
        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<EmailExistsFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists.EmailExistsFunction class.
        /// </summary>
        /// <param name="repositoryFactory">Create objects from repositories</param>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="logger">Log</param>
        public EmailExistsFunction(
                IRepositoryFactory repositoryFactory,
                ITransactionScope transactionScope,
                IUserRepository repository,
                ILogger<EmailExistsFunction> logger
            )
        {
            _repositoryFactory = repositoryFactory;
            _transactionScope = transactionScope;
            _repository = repository;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the function.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<bool> ExecuteAsync(EmailExistsFunctionRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var rules = new List<IRule<UserEntityField>>
                {
                    _repositoryFactory.CreateRule(UserEntityField.Email, SqlComparisonOperator.EqualTo, request.Email)
                };

            if (request.UserId.HasValue)
            {
                rules.Add(_repositoryFactory.CreateRule(UserEntityField.Id_Readonly, SqlComparisonOperator.NotEqualTo, request.UserId.Value, SqlOperator.And));
            }

            var rule = _repositoryFactory.CreateRule(rules.ToArray());

            var response = await _transactionScope
                                .UsingAsync(async scope => await _repository.ExistsAsync(scope, rule))
                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
