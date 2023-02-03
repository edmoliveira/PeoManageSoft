using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Filters
{
    /// <summary>
    /// Log the request data and set request id.
    /// </summary>
    public sealed class LogFilterAttribute : ActionFilterAttribute
    {
        #region Fields

        /// <summary>
        /// One instance throughout the application per request.
        /// </summary>
        private readonly ISetApplicationContext _applicationContext;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<LogFilterAttribute> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the  PeoManageSoft.Business.Infrastructure.Filters.LogFilterAttribute class.
        /// </summary>
        /// <param name="applicationContext">One instance throughout the application per request.</param>
        /// <param name="logger">Log</param>
        public LogFilterAttribute(ISetApplicationContext applicationContext, ILogger<LogFilterAttribute> logger)
        {
            _applicationContext = applicationContext;
            _logger = logger;
        }

        #endregion

        #region Method public

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">Information about the current request and action</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue(InfraSettings.RequestIdHeaderKey, out StringValues requestId))
            {
                _applicationContext.SetRequestId(requestId.FirstOrDefault());
            }
            else
            {
                _applicationContext.SetRequestId(Guid.NewGuid().ToString("N"));
            }

            if (context.HttpContext.Request.Headers.TryGetValue(InfraSettings.AuthorizationHeaderKey, out StringValues authorization))
            {
                AuthenticationHeaderValue token = AuthenticationHeaderValue.Parse(authorization.FirstOrDefault());

                _applicationContext.SetToken(token.Parameter);
            }

            if (context.HttpContext.Request.Headers.TryGetValue(InfraSettings.SerialNumberHeaderKey, out StringValues serialNumber))
            {
                _applicationContext.SetSerialNumber(serialNumber.FirstOrDefault());
            }

            if (context.HttpContext.User.Identity is ClaimsIdentity claimsIdentity &&
                claimsIdentity.IsAuthenticated)
            {
                _applicationContext.SetLoggedUser(new LoggedUser(claimsIdentity));
            }
            else
            {
                _applicationContext.SetLoggedUser(new LoggedUser());
            }

            _logger.DebugIsEnabled(() => string.Concat("Request.Query: ", JsonConvert.SerializeObject(context?.HttpContext?.Request?.Query)));
        }

        #endregion
    }
}
