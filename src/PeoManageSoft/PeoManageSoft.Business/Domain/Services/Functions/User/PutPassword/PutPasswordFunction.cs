using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.PutPassword
{
    /// <summary>
    /// Function that updates the user's password.
    /// </summary>
    internal sealed class PutPasswordFunction : IPutPasswordFunction
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
        private readonly ILogger<PutPasswordFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.PutPassword.PutPasswordFunction class.
        /// </summary>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public PutPasswordFunction(
                IPatchHandler patchHandler,
                IMapper mapper,
                ILogger<PutPasswordFunction> logger
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
        /// <param name="request">Request for the function.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteAsync(PutPasswordFunctionRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = request.UserId,
                Fields = new List<Field<UserEntityField>>
                    {
                        new Field<UserEntityField> {
                            Type = UserEntityField.Password,
                            Value = request.EncryptedPassword
                        }
                    }
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
