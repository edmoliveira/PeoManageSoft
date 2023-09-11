using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Contains the options used by the Microsoft.AspNetCore.Authentication.AuthenticationHandler.
    /// </summary>
    internal sealed class NetAuthenticationOptions : AuthenticationSchemeOptions
    {
        #region Properties

        /// <summary>
        /// Invoked when a validation of the authentication token is called.
        /// </summary>
        /// <remarks>
        ///     string: 
        ///         Token for validation
        ///     AuthenticationScheme:
        ///         AuthenticationSchemes assign a name to a specific Microsoft.AspNetCore.Authentication.IAuthenticationHandler        
        ///         handlerType.
        ///     Task<NetResultValidToken>:
        ///         Token validation result
        /// </remarks>
        public Func<string, AuthenticationScheme, IServiceProvider, ILogger, Task<NetResultValidToken>> ValidTokenAsync { get; set; }

        #endregion
    }
}
