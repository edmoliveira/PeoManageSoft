using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Functions.Title.Exists
{
    /// <summary>
    /// Function that determines whether the specified title table contains the record that match the id
    /// </summary>
    internal sealed class ExistsFunction : IExistsFunction
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly ITitleRepository _repository;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ExistsFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.Title.Exists.ExistsFunction class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="logger">Log</param>
        public ExistsFunction(
                ITransactionScope transactionScope,
                ITitleRepository repository,
                ILogger<ExistsFunction> logger
            )
        {
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
        /// <param name="id">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<bool> ExecuteAsync(long id)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var response = await _transactionScope
                                .UsingAsync(async scope => await _repository.ExistsAsync(scope, id))
                                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
