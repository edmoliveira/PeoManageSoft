using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.Title;
using PeoManageSoft.Business.Application.Title.Change;
using PeoManageSoft.Business.Application.Title.Delete;
using PeoManageSoft.Business.Application.Title.New;
using PeoManageSoft.Business.Application.Title.Read;
using PeoManageSoft.Business.Application.Title.Read.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Controllers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PeoManageSoft.Api.Controllers.Titles
{
    /// <summary>
    /// Title CRUD.
    /// </summary>
    [ApiController]
    [RequireHttps]
    [Produces("application/json")]
    [Route("api/titles")]
    [SerialNumberAuthorizationFilter]
    [Authorize()]
    public sealed class TitlesController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// Title Facade that provides a simplified interface.
        /// </summary>
        private readonly ITitleApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Document.Management.Api.Controllers.Titles.TitlesControllers class.
        /// </summary>
        /// <param name="facade">Title Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public TitlesController(ITitleApplicationFacade facade, ILogger<TitlesController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the title by id.
        /// </summary>
        /// <param name="id">Title id</param>
        /// <returns>TitleResponse</returns>
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
            Summary = "Get Title",
            Description = "Gets the title by id."
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
        /// Gets all registered titles.
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
            Summary = "Get All Titles",
            Description = "Gets all registered titles."
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
        /// Registers an new title and asynchronously using Task.
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
            Summary = "Add Title",
            Description = "Registers an new title."
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
        /// Updates an title data.
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
            Summary = "Update Title",
            Description = "Updates an title data."
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
        /// Removes an title.
        /// </summary>
        /// <param name="id">Title id</param>
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
            Summary = "Remove Title",
            Description = "Removes an title."
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


