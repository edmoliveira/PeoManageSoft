namespace PeoManageSoft.Business.Domain.Services.Apis.Geo.Interfaces
{
    /// <summary>
    /// Reverse geocoding is the process of converting geographic coordinates into a human-readable address.
    /// </summary>
    internal interface IGeoApi
    {
        #region Methods

        /// <summary>
        /// Finds the address by latitude and longitude
        /// </summary>
        /// <param name="latitude">It shows the angle between the straight line in the certain point and the equatorial plane.</param>
        /// <param name="longitude">It shows another angular coordinate defining the position of a point on a surface of earth.</param>
        /// <returns>Returns the address</returns>
        Task<string> FindAddressByLatLongAsync(double latitude, double longitude);

        #endregion
    }
}
