using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Add policy command.
    /// </summary>
    internal sealed class AddPolicyCommand : IAddPolicyCommand
    {
        #region Fields

        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddPolicyCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Add.AddPolicyCommand class.
        /// </summary>
        /// <param name="logger">Log</param>
        public AddPolicyCommand(ILogger<AddPolicyCommand> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="collection">The type of the cross-platform NoSQL collection.</param>
        /// <param name="request">NoSql documents "Policy"..</param>
        /// <returns>Represents an asynchronous operation. </returns>
        public async Task ExecuteAsync(IPolicyCollection collection, IEnumerable<PolicyDocument> request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await collection.InsertManyAsync(request).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
