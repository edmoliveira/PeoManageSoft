using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.PutLocation
{
    /// <summary>
    /// Request data.
    /// </summary>
    internal sealed class PutLocationFunctionRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// User location
        /// </summary>
        public GeoLocation Location { get; set; }

        #endregion
    }
}
