using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Update resource command.
    /// </summary>
    internal sealed class UpdateResourceCommand : IUpdateResourceCommand
    {
        #region Fields

        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<UpdateResourceCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Update.UpdateResourceCommand class.
        /// </summary>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public UpdateResourceCommand(
                IMapper mapper,
                ILogger<UpdateResourceCommand> logger)
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
        public async Task ExecuteAsync(IRoleCollection collection, UpdateResourceRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var documents = await collection.FindAsync(p => p.RoleId == request.RoleId).ConfigureAwait(false);
            var document = documents.FirstOrDefault();

            _mapper.Map(request, document);

            await collection.UpdateAsync(document).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
