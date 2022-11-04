using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources
{
    /// <summary>
    /// Platform Images catalog.
    /// </summary>
    internal sealed class ImagesCatalogResource: IImagesCatalogResource
    {
        #region Properties

        /// <summary>
        /// Platform Logo
        /// </summary>
        /// <remarks>
        /// width  = 64 
        /// height = 64
        /// </remarks>
        public string Logo64x64 { get; set; }
        /// <summary>
        /// Platform Logo
        /// </summary>
        /// <remarks>
        /// width  = 64 
        /// height = 64
        /// </remarks>
        public string Logo518x518 { get; set; }
        /// <summary>
        /// Keys
        /// </summary>
        /// <remarks>
        /// width  = 256 
        /// height = 256
        /// </remarks>
        public string Keys256x256 { get; set; }

        #endregion
    }
}
