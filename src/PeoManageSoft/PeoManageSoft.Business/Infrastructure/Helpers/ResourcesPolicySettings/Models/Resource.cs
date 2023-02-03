namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Models
{
    /// <summary>
    /// Application resource
    /// </summary>
    internal sealed class Resource
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Roles that have resource permissions
        /// </summary>
        public int[] Roles { get; set; }

        #endregion
    }
}
