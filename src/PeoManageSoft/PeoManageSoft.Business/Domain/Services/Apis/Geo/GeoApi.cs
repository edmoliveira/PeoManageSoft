using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Apis.Geo.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Domain.Services.Apis.Geo
{
    /// <summary>
    /// Reverse geocoding is the process of converting geographic coordinates into a human-readable address.
    /// </summary>
    internal sealed class GeoApi : IGeoApi
    {
        #region Fields private

        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GeoApi> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Apis.Geo.GeoApi class.
        /// </summary>
        /// <param name="logger">Log</param>
        public GeoApi(ILogger<GeoApi> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Method 

        #region public

        /// <summary>
        /// Finds the address by latitude and longitude
        /// </summary>
        /// <param name="latitude">It shows the angle between the straight line in the certain point and the equatorial plane.</param>
        /// <param name="longitude">It shows another angular coordinate defining the position of a point on a surface of earth.</param>
        /// <returns>Returns the address</returns>
        public async Task<string> FindAddressByLatLongAsync(double latitude, double longitude)
        {
            string methodName = nameof(FindAddressByLatLongAsync);

            _logger.LogBeginInformation(methodName);

            var address = await Task.Run(() => "").ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return address;
        }

        #endregion

        #endregion
    }
}
