using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.ValidatePasswordToken;
using PeoManageSoft.Business.Infrastructure.Helpers.Controllers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace PeoManageSoft.Api.Controllers.Users
{
    /// <summary>
    /// Platform security.
    /// </summary>
    [ApiController]
    [RequireHttps]
    [Produces("application/json")]
    [Route("api/users/validate-password-token")]
    [AllowAnonymous]
    [SerialNumberAuthorizationFilter]
    public class ValidatePasswordTokenController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// User Facade that provides a simplified interface.
        /// </summary>
        private readonly IUserApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Api.Controllers.Users.ValidPasswordTokenController class.
        /// </summary>
        /// <param name="facade">User Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public ValidatePasswordTokenController(IUserApplicationFacade facade, ILogger<ValidatePasswordTokenController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Method public

        /// <summary>
        /// Validates if the password token is valid.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>ValidPasswordTokenResponse</returns>
        [ApiExplorerSettings(GroupName = Security_GroupName)]
        [HttpPost()]
        [ApiVersion("1.0")]
        [Route("{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(ValidatePasswordTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Validate password token",
            Description = "Validates if the password token is valid."
        )]
        public async Task<IActionResult> ValidatePasswordTokenAsync(ValidatePasswordTokenRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(ValidatePasswordTokenAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                ValidatePasswordTokenResponse response = await _facade.ValidatePasswordTokenAsync(request).ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        #endregion
    }
}

