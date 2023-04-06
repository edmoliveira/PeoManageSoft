namespace PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Interfaces
{
    /// <summary>
    /// Resources policy configuration.
    /// </summary>
    internal interface IResourcesPolicyConfiguration
    {
        #region Methods

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns>Resources</returns>
        IEnumerable<string> GetResources();

        #endregion
    }
}
