using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models;

namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Interfaces
{
    /// <summary>
    /// Resources policy configuration.
    /// </summary>
    internal interface IResourcesPolicyConfiguration
    {
        #region Methods

        /// <summary>
        /// Gets the resource policies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Policy> GetPolicies(UserRole userRole);

        #endregion
    }
}
