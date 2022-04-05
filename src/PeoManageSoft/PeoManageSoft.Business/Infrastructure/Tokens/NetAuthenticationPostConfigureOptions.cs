using Microsoft.Extensions.Options;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Represents something that configures the TOptions type. Note: These are run after
    /// all Microsoft.Extensions.Options.IConfigureOptions`1.
    /// </summary>
    public sealed class NetAuthenticationPostConfigureOptions : IPostConfigureOptions<NetAuthenticationOptions>
    {
        #region Methods public

        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="name">The name of the options instance being configured.</param>
        /// <param name="options">The options instance to configured.</param>
        public void PostConfigure(string name, NetAuthenticationOptions options)
        {
            if (options.ValidTokenAsync == null)
            {
                throw new InvalidOperationException("ValidToken must be provided in options");
            }
        }

        #endregion
    }
}