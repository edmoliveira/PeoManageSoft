using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.Role;
using PeoManageSoft.Business.Application.Role.Change;
using PeoManageSoft.Business.Application.Role.Delete;
using PeoManageSoft.Business.Application.Role.New;
using PeoManageSoft.Business.Application.Role.Read;
using PeoManageSoft.Business.Application.Role.Read.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Controllers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PeoManageSoft.Api.Controllers.Roles
{
    /// <summary>
    /// Role CRUD.
    /// </summary>
    [ApiController]
    [RequireHttps]
    [Produces("application/json")]
    [Route("api/roles")]
    [SerialNumberAuthorizationFilter]
    [Authorize()]
    public sealed class RolesController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// Role Facade that provides a simplified interface.
        /// </summary>
        private readonly IRoleApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Document.Management.Api.Controllers.Roles.RolesControllers class.
        /// </summary>
        /// <param name="facade">Role Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public RolesController(IRoleApplicationFacade facade, ILogger<RolesController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the role by id.
        /// </summary>
        /// <param name="id">Role id</param>
        /// <returns>RoleResponse</returns>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
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
            Summary = "Get Role",
            Description = "Gets the role by id."
        )]
        public async Task<IActionResult> GetAsync([Required] long id)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(GetAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", id));

                ReadResponse response = await _facade.GetAsync(new ReadRequest { Id = id }).ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all registered roles.
        /// </summary>
        /// <returns>IEnumerable<ReadAllResponse></returns>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
        [HttpGet()]
        [ApiVersion("1.0")]
        [Route("{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(IEnumerable<ReadResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get All Roles",
            Description = "Gets all registered roles."
        )]
        public async Task<IActionResult> GetAllAsync()
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(GetAllAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                IEnumerable<ReadResponse> response = await _facade.GetAllAsync().ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Registers an new role and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
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
            Summary = "Add Role",
            Description = "Registers an new role."
        )]
        public async Task<IActionResult> AddAsync([BindRequired] NewRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(AddAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                ValidateModelState();

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                NewResponse response = await _facade.AddAsync(request).ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an role data.
        /// </summary>
        /// <param name="request">Request data</param>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
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
            Summary = "Update Role",
            Description = "Updates an role data."
        )]
        public async Task<IActionResult> UpdateAsync([BindRequired] ChangeRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(UpdateAsync);

                ValidateModelState();

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                await _facade.UpdateAsync(request).ConfigureAwait(false);

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes an role.
        /// </summary>
        /// <param name="id">Role id</param>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
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
            Summary = "Remove Role",
            Description = "Removes an role."
        )]
        public async Task<IActionResult> RemoveAsync([Required] long id)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(RemoveAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", id));

                await _facade.RemoveAsync(new DeleteRequest { Id = id }).ConfigureAwait(false);

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return NoContent();
            }).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}


