using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Filters
{
    /// <summary>
    /// Authentication the serial number.
    /// </summary>
    public sealed class SerialNumberAuthorizationFilterAttribute : ActionFilterAttribute
    {
        #region Method public

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">Information about the current request and action</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.RequestServices.GetService(typeof(IAppConfig)) is not IAppConfig appConfig)
            {
                throw new ProviderServiceNotFoundException(nameof(IAppConfig));
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(ApplicationResource.SerialNumberHeaderKey, out StringValues serialNumber) ||
                serialNumber.FirstOrDefault() != appConfig.SerialNumber)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        #endregion
    }
}
