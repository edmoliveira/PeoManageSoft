using Microsoft.Extensions.Configuration;
using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models;
using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

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
        /// Gets the resource policies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Policy> GetPolicies(UserRole userRole)
        {
            Grant createGrant(int[] roles)
            {
                bool hasPermission = roles.Any(role => role == (int)userRole);

                return new Grant(hasPermission, hasPermission, hasPermission, hasPermission);
            }

            return _resourcePolicyConfig.Resources.Select(item => new Policy
            {
                ResourceName = item.Name,
                Permissions = createGrant(item.Roles)
            });
        }

        #endregion

        #endregion
    }
}
