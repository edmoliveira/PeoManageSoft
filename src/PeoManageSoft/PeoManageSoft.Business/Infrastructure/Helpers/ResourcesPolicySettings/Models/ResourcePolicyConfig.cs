using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models
{
    /// <summary>
    /// Application resources configuration.
    /// </summary>
    internal sealed class ResourcePolicyConfig
    {
        #region Properties

        /// <summary>
        /// Application resources
        /// </summary>
        public IEnumerable<Resource> Resources { get; set; }
        /// <summary>
        /// Application resources descriptions
        /// </summary>
        public Dictionary<ApplicationLanguage, Dictionary<string, string>> ResourcesDescriptions { get; set; }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Tries to get the resource description.
        /// </summary>
        /// <param name="appConfig">Application configuration</param>
        /// <param name="resourceName">Resource name</param>
        /// <param name="description">Resource description</param>
        /// <returns>true if the ResourcesDescriptions contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetResourceDescription(IAppConfig appConfig, string resourceName, out string description)
        {
            description = null;

            var result = ResourcesDescriptions.TryGetValue(appConfig.ApplicationLanguage, out var dictionary);

            if (result)
            {
                result = dictionary.TryGetValue(resourceName, out description);
            }

            return result;
        }

        #endregion

        #endregion
    }
}
