namespace PeoManageSoft.Business.Infrastructure.Helpers.Structs
{
    /// <summary>
    /// Struct with Latitude and Longitude.
    /// </summary>
    /// <param name="Latitude">It shows the angle between the straight line in the certain point and the equatorial plane.</param>
    /// <param name="Longitude">It shows another angular coordinate defining the position of a point on a surface of earth.</param>
    public readonly record struct GeoLocation(double Latitude, double Longitude)
    {
        /// <summary>
        /// Finds Latitude and Longitude in the string.
        /// </summary>
        /// <param name="value">Latitude and Longitude separated by comma.</param>
        public static implicit operator GeoLocation(string value)
        {
            if(value is null) { return new GeoLocation(0, 0); }

            var array = value.Split(';');

            if(array.Length < 2) { return new GeoLocation(0, 0); }

            _ = double.TryParse(array[0], out double latitude);
            _ = double.TryParse(array[1], out double longitude);

            return new GeoLocation(latitude, longitude);
        }

        /// <summary>
        /// Concatenates Latitude and Longitude separated by comma.
        /// </summary>
        /// <returns>Latitude and Longitude</returns>
        public override string ToString()
        {
            return $"{Latitude};{Longitude}";
        }
    }
}