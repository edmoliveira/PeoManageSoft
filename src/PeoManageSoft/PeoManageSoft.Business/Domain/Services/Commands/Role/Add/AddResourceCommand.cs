using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Add resource command.
    /// </summary>
    internal sealed class AddResourceCommand : IAddResourceCommand
    {
        #region Fields

        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddResourceCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Add.AddResourceCommand class.
        /// </summary>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public AddResourceCommand(
                IMapper mapper,
                ILogger<AddResourceCommand> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="collection">The type of the cross-platform NoSQL collection.</param>
        /// <param name="request">Request for the add resource command.</param>
        /// <returns>Represents an asynchronous operation. </returns>
        public async Task ExecuteAsync(IRoleCollection collection, AddResourceRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await collection.InsertAsync(new RoleDocument(
                    request.RoleId,
                    _mapper.Map<IEnumerable<ResourceDocument>>(request.Resources)
                )).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}

