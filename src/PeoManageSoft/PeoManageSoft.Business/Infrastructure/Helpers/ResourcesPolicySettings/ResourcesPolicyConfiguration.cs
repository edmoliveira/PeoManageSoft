using Microsoft.Extensions.Configuration;
using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models;

namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings
{
    /// <summary>
    /// Resources policy configuration.
    /// </summary>
    internal sealed class ResourcesPolicyConfiguration : IResourcesPolicyConfiguration
    {
        #region Fields

        /// <summary>
        /// Application resources configuration.
        /// </summary>
        private readonly ResourcePolicyConfig _resourcePolicyConfig;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.ResourcesPolicyConfiguration class.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        public ResourcesPolicyConfiguration(IConfiguration configuration)
        {
            _resourcePolicyConfig = configuration.GetSection("ResourcePolicyConfig").Get<ResourcePolicyConfig>();
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns>Resources</returns>
        public IEnumerable<string> GetResources()
        {
            return _resourcePolicyConfig.Resources.Select(item => item.Name);
        }

        #endregion

        #endregion
    }
}
