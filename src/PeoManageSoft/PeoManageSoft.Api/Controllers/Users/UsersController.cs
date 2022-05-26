using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.ReadAll.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Controllers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace PeoManageSoft.Api.Controllers.Users
{
    /// <summary>
    /// User CRUD.
    /// </summary>
    [ApiController]
    [RequireHttps]
    [Produces("application/json")]
    [Route("api/users")]
    [SerialNumberAuthorizationFilter]
    //[AuthorizeRoles(UserRole.Admin)]
    public sealed class UsersController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// User Facade that provides a simplified interface.
        /// </summary>
        private readonly IUserApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Document.Management.Api.Controllers.Users.UsersControllers class.
        /// </summary>
        /// <param name="facade">User Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public UsersController(IUserApplicationFacade facade, ILogger<UsersController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Method 

        #region public

        /// <summary>
        /// Gets all registered users.
        /// </summary>
        /// <returns>IEnumerable<ReadAllResponse></returns>
        [ApiExplorerSettings(GroupName = "Users")]
        [HttpGet()]
        [ApiVersion("1.0")]
        [Route("{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(IEnumerable<ReadAllResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get All Users",
            Description = "Gets all registered users."
        )]
        public async Task<IActionResult> GetAllAsync()
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(GetAllAsync);

                _Logger.LogInformation(GetMethodBeginMessage(methodName));

                IEnumerable<ReadAllResponse> response = await _facade.GetAllAsync().ConfigureAwait(false);

                _Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                _Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Registers an new user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        [ApiExplorerSettings(GroupName = "Users")]
        [HttpPost()]
        [ApiVersion("1.0")]
        [Route("{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(NewResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Add User",
            Description = "Registers an new user."
        )]
        public async Task<IActionResult> AddAsync([BindRequired] NewRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(AddAsync);

                _Logger.LogInformation(GetMethodBeginMessage(methodName));

                ValidateModelState();

                _Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                NewResponse response = await _facade.AddAsync(request).ConfigureAwait(false);

                _Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                _Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}


