using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.ActivateUser;
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
    [Route("api/users/active-user")]
    [AllowAnonymous]
    [SerialNumberAuthorizationFilter]
    public class ActivateUserController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// User Facade that provides a simplified interface.
        /// </summary>
        private readonly IUserApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Api.Controllers.Users.ActivateUserController class.
        /// </summary>
        /// <param name="facade">User Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public ActivateUserController(IUserApplicationFacade facade, ILogger<ActivateUserController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Method public

        /// <summary>
        /// Activates the user if the user token is valid. 
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>void</returns>
        [ApiExplorerSettings(GroupName = Security_GroupName)]
        [HttpPatch()]
        [ApiVersion("1.0")]
        [Route("{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Activate user",
            Description = "Activates the user if the user token is valid. "
        )]
        public async Task<IActionResult> CreateNewPasswordAsync(ActivateUserRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(CreateNewPasswordAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                await _facade.ActivateUserAsync(request).ConfigureAwait(false);

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        #endregion
    }
}
