using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Application.User.SendPasswordToken
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class SendPasswordTokenRequest
    {
        #region Properties

        /// <summary>
        /// Application url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Indicates the last location where the user logged in "Longitude and latitude"
        /// </summary>
        public GeoLocation Location { get; set; }

        #endregion
    }
}