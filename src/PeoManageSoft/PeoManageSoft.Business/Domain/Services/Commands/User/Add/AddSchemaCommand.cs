using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Add schema command.
    /// </summary>
    internal sealed class AddSchemaCommand : IAddSchemaCommand
    {
        #region Fields

        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<AddSchemaCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Add.AddSchemaCommand class.
        /// </summary>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public AddSchemaCommand(
                IMapper mapper,
                ILogger<AddSchemaCommand> logger)
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
        /// <param name="request">Request for the add schema command.</param>
        /// <returns>Represents an asynchronous operation. </returns>
        public async Task ExecuteAsync(ISchemaCollection collection, AddSchemaRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await collection.InsertAsync(new SchemaDocument(
                    request.UserId,
                    _mapper.Map<IEnumerable<ResourceDocument>>(request.Resources)
                )).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
