using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeoManageSoft.Business.Application.User;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Application.User.ReadAllWithPagination;
using PeoManageSoft.Business.Application.User.SearchWithPagination;
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
    [Authorize()]
    public sealed class PaginationController : CustomControllerBase
    {
        #region Fields private

        /// <summary>
        /// User Facade that provides a simplified interface.
        /// </summary>
        private readonly IUserApplicationFacade _facade;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Document.Management.Api.Controllers.Users.GetAllWithPaginationController class.
        /// </summary>
        /// <param name="facade">User Facade that provides a simplified interface.</param>
        /// <param name="logger">Log</param>
        public PaginationController(IUserApplicationFacade facade, ILogger<PaginationController> logger) : base(logger)
        {
            _facade = facade;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets all registered users with pagination
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>IEnumerable<ReadAllResponse></returns>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
        [HttpPost()]
        [ApiVersion("1.0")]
        [Route("get-all-with-pagination/{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(IEnumerable<ReadResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Get All Users",
            Description = "Gets all registered users with pagination."
        )]
        public async Task<IActionResult> GetAllWithPaginationAsync(ReadAllWithPaginationRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(GetAllWithPaginationAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                IEnumerable<ReadResponse> response = await _facade.GetAllWithPaginationAsync(request).ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Search users with pagination
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>IEnumerable<ReadAllResponse></returns>
        [ApiExplorerSettings(GroupName = Crud_GroupName)]
        [HttpPost()]
        [ApiVersion("1.0")]
        [Route("search-with-pagination/{v:apiVersion}")]
        [TypeFilter(typeof(LogFilterAttribute))]
        [ProducesResponseType(typeof(IEnumerable<ReadResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Search Users",
            Description = "Search users with pagination."
        )]
        public async Task<IActionResult> SearchWithPaginationAsync(SearchWithPaginationRequest request)
        {
            return await TryActionResultAsync(async stopwatch =>
            {
                string methodName = nameof(SearchWithPaginationAsync);

                Logger.LogInformation(GetMethodBeginMessage(methodName));

                Logger.DebugIsEnabled(() => string.Concat("Request: ", JsonConvert.SerializeObject(request)));

                IEnumerable<ReadResponse> response = await _facade.SearchWithPaginationAsync(request).ConfigureAwait(false);

                Logger.DebugIsEnabled(() => string.Concat("Response: ", JsonConvert.SerializeObject(response)));

                Logger.LogInformation(GetMethodEndMessage(methodName, stopwatch.StopAndGetMilliseconds()));

                return Ok(response);
            }).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}
