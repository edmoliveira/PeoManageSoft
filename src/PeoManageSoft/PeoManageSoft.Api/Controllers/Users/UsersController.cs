using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Application.User.ReadAll.Response;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Attributes;
using PeoManageSoft.Business.Infrastructure.Helpers.Controllers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

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
    [AuthorizeRoles(UserRole.Admin)]
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
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>UserResponse</returns>
        [ApiExplorerSettings(GroupName = "Users")]
        [HttpGet()]
        [ApiVersion("1.0")]
        [Route("{id}/{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(ReadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get User",
            Description = "Gets the user by id."
        )]
        public async Task<IActionResult> GetAsync([Required] long id)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(GetAsync);

                _Logger.LogInformation(GetMethodBeginMessage(methodName));

                _Logger.DebugIsEnabled(() => string.Concat("Request: ", id));

                ReadResponse response = await _facade.GetAsync(new ReadRequest { Id = id }).ConfigureAwait(false);

                _Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                _Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

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

        /// <summary>
        /// Updates an user data.
        /// </summary>
        /// <param name="request">Request data</param>
        [ApiExplorerSettings(GroupName = "Users")]
        [HttpPut()]
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
            Summary = "Update User",
            Description = "Updates an user data."
        )]
        public async Task<IActionResult> UpdateAsync([BindRequired] ChangeRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(UpdateAsync);

                _Logger.LogInformation(GetMethodBeginMessage(methodName));

                _Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                await _facade.UpdateAsync(request).ConfigureAwait(false);

                _Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes an user.
        /// </summary>
        /// <param name="id">User id</param>
        [ApiExplorerSettings(GroupName = "Users")]
        [HttpDelete()]
        [ApiVersion("1.0")]
        [Route("{id}/{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Remove User",
            Description = "Removes an user."
        )]
        public async Task<IActionResult> RemoveAsync([Required] long id)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(RemoveAsync);

                _Logger.LogInformation(GetMethodBeginMessage(methodName));

                _Logger.DebugIsEnabled(() => string.Concat("Request: ", id));

                await _facade.RemoveAsync(new DeleteRequest { Id = id }).ConfigureAwait(false);

                _Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}


