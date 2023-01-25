using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;
using Ubiety.Dns.Core;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Handles all commands to add the user.
    /// </summary>
    internal sealed class AddHandler : IAddHandler
    {
        #region Fields

        /// <summary>
        /// Create the code block transactional.
        /// </summary>
        private readonly ITransactionScope _transactionScope;
        /// <summary>
        /// Makes a code block. 
        /// </summary>
        private readonly IScopeNoSql _scopeNoSql;
        /// <summary>
        /// Add user command.
        /// </summary>
        private readonly IAddCommand _command;
        /// <summary>
        /// Add policy command.
        /// </summary>
        private readonly IAddPolicyCommand _policyCommand;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Add.AddHandler class.
        /// </summary>
        /// <param name="transactionScope">Create the code block transactional.</param>
        /// <param name="scopeNoSql">Makes a code block.</param>
        /// <param name="command">Add user command.</param>
        /// <param name="policyCommand">Add policy command.</param>
        /// <param name="_mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public AddHandler(
                ITransactionScope transactionScope,
                IScopeNoSql scopeNoSql,
                IAddCommand command,
                IAddPolicyCommand policyCommand,
                IMapper mapper,
                ILogger<AddHandler> logger
            )
        {
            _transactionScope = transactionScope;
            _scopeNoSql = scopeNoSql;
            _command = command;
            _policyCommand = policyCommand;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the add user command
        /// </summary>
        /// <param name="request">Request for the add user command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add user command.
        /// </returns>
        public async Task<AddResponse> HandleAsync(AddRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            AddResponse result = await _transactionScope
                                            .UsingAsync(async scope => {
                                                scope.BeginTransaction();

                                                var response = await _command.ExecuteAsync(scope, request).ConfigureAwait(false);

                                                await _scopeNoSql.UsingAsync(async rep =>
                                                {
                                                    var documents = _mapper.Map<IEnumerable<PolicyDocument>>(request.Policies);

                                                    await _policyCommand.ExecuteAsync(
                                                            rep.Authorization.Policy,
                                                            documents
                                                    ).ConfigureAwait(false);

                                                }).ConfigureAwait(false); 

                                                return response;
                                            })
                                            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
