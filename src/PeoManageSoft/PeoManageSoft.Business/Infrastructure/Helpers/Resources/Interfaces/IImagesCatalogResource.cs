namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces
{
    /// <summary>
    /// Platform Images catalog.
    /// </summary>
    internal interface IImagesCatalogResource
    {
        #region Properties

        /// <summary>
        /// Platform Logo
        /// </summary>
        /// <remarks>
        /// width  = 64 
        /// height = 64
        /// </remarks>
        string Logo64x64 { get; }
        /// <summary>
        /// Platform Logo
        /// </summary>
        /// <remarks>
        /// width  = 64 
        /// height = 64
        /// </remarks>
        string Logo518x518 { get; }
        /// <summary>
        /// Keys
        /// </summary>
        /// <remarks>
        /// width  = 256 
        /// height = 256
        /// </remarks>
        string Keys256x256 { get; }

        #endregion
    }
}
