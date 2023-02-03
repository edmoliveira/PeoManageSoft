using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using PeoManageSoft.Business.Infrastructure.Helpers;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// An opinionated abstraction for implementing IAuthenticationHandler
    /// </summary>
    internal sealed class NetAuthenticationHandler : AuthenticationHandler<NetAuthenticationOptions>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Tokens.NetAuthenticationHandler class.
        /// </summary>
        /// <param name="options">Used for notifications when TOptions instances change.</param>
        /// <param name="logger">
        /// Represents a type used to configure the logging system and create instances of
        /// Microsoft.Extensions.Logging.ILogger from the registered Microsoft.Extensions.Logging.ILoggerProviders.
        /// </param>
        /// <param name="encoder">Represents a URL character encoding.</param>
        /// <param name="clock">Abstracts the system clock to facilitate testing.</param>
        public NetAuthenticationHandler(
            IOptionsMonitor<NetAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }

        #endregion

        #region Methods protected

        /// <summary>
        /// Allows derived types to handle authentication.
        /// </summary>
        /// <returns>Contains the result of an Authenticate call</returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                NetResultValidToken result = new() { Sucess = false };
                string headerKey = InfraSettings.AuthorizationHeaderKey;

                if (Request.Headers.TryGetValue(headerKey, out StringValues authorization))
                {
                    AuthenticationHeaderValue token = AuthenticationHeaderValue.Parse(authorization.FirstOrDefault());

                    result = await Options.ValidTokenAsync(token.Parameter, Scheme).ConfigureAwait(false);
                }

                return result.Sucess ?
                    AuthenticateResult.Success(new AuthenticationTicket(result.Principal, Scheme.Name)) :
                    AuthenticateResult.Fail("Not Authorized");
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);

                return AuthenticateResult.Fail("Not Authorized");
            }
        }

        #endregion
    }
}
