using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.SendReminderActivateUser;
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
    [Route("api/users/send-reminder-activate-user")]
    [AllowAnonymous]
    [SerialNumberAuthorizationFilter]
    public class SendReminderActivateUserController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// User Facade that provides a simplified interface.
        /// </summary>
        private readonly IUserApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Api.Controllers.Users.SendReminderActivateUserController class.
        /// </summary>
        /// <param name="facade">User Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public SendReminderActivateUserController(IUserApplicationFacade facade, ILogger<SendReminderActivateUserController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Method public

        /// <summary>
        /// Sends an email with a reminder to activate the user.
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
            Summary = "Send reminder to activate user",
            Description = "Sends an email with a reminder to activate the user."
        )]
        public async Task<IActionResult> SendReminderToActivateUserAsync(SendReminderActivateUserRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(SendReminderToActivateUserAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                await _facade.SendReminderActivateUserAsync(request).ConfigureAwait(false);

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        #endregion
    }
}
