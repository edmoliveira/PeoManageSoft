using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models
{
    /// <summary>
    /// Resourse policy.
    /// </summary>
    internal sealed class Policy
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }

        #endregion
    }
}
