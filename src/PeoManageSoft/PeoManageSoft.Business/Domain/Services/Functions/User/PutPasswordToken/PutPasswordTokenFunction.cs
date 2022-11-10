using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.PutPasswordToken
{
    /// <summary>
    /// Function that updates the user's passwordToken.
    /// </summary>
    internal sealed class PutPasswordTokenFunction : IPutPasswordTokenFunction
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
        private readonly ILogger<PutPasswordTokenFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.PutPasswordToken.PutPasswordTokenFunction class.
        /// </summary>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public PutPasswordTokenFunction(
                IPatchHandler patchHandler,
                IMapper mapper,
                ILogger<PutPasswordTokenFunction> logger
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
        public async Task ExecuteAsync(PutPasswordTokenFunctionRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = request.UserId,
                Fields = new List<Field<UserEntityField>>
                    {
                        new Field<UserEntityField> {
                            Type = UserEntityField.PasswordToken,
                            Value = request.PasswordToken
                        }
                    }
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
