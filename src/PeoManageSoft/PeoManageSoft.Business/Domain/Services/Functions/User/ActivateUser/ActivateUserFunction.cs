using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.ActivateUser
{
    /// <summary>
    /// Function that activates the user.
    /// </summary>
    internal sealed class ActivateUserFunction : IActivateUserFunction
    {
        #region Fields

        /// <summary>
        /// Handles all commands to patch the user.
        /// </summary>
        private readonly IPatchHandler _patchHandler;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ActivateUserFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.ActivateUser.ActivateUserFunction class.
        /// </summary>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public ActivateUserFunction(
                IPatchHandler patchHandler,
                IMapper mapper,
                ILogger<ActivateUserFunction> logger
            )
        {
            _patchHandler = patchHandler;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(long userId)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = userId,
                Fields = new List<Field<UserEntityField>>
                    {
                        new Field<UserEntityField> {
                            Type = UserEntityField.IsActive,
                            Value = true
                        }
                    }
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
