using Microsoft.AspNetCore.Authentication;
using PeoManageSoft.Business.Infrastructure.Tokens;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Extensions
{
    /// <summary>
    /// Authentication extension
    /// </summary>
    internal static class NetBearerExtension
    {
        #region Methods public

        /// <summary>
        /// Authentication extension method
        /// </summary>
        /// <param name="builder">Used to configure authentication</param>
        /// <param name="configureOptions"></param>
        /// <returns>Used to configure authentication</returns>
        public static AuthenticationBuilder AddNetBearer(this AuthenticationBuilder builder, Action<NetAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<NetAuthenticationOptions, NetAuthenticationHandler>(NetBearerDefaults.AuthenticationScheme, configureOptions);
        }

        #endregion
    }
}
