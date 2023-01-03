namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Safely convert values
    /// </summary>
    public static class SafeConvert
    {
        #region Methods 

        #region public

        /// <summary>
        /// Converts the content representation of a number to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="value">A content to be converted.</param>
        /// <returns>Returns the converted content if successful otherwise returns 0.</returns>
        public static int ToInt(object value)
        {
            return value != null && int.TryParse(value.ToString(), out int result) ? result : 0;
        }

        /// <summary>
        /// Converts the content representation of a number to its 64-bit signed integer equivalent.
        /// </summary>
        /// <param name="value">A content to be converted.</param>
        /// <returns>Returns the converted content if successful otherwise returns 0.</returns>
        public static long ToLong(object value)
        {
            return value != null && long.TryParse(value.ToString(), out long result) ? result : 0;
        }

        /// <summary>
        /// Converts the specified content representation of a logical value to its System.Boolean equivalent.
        /// </summary>
        /// <param name="value">A content to be converted.</param>
        /// <returns>Returns the converted content if successful otherwise returns false.</returns>
        public static bool ToBoolean(object value)
        {
            return value != null && bool.TryParse(value.ToString(), out bool result) && result;
        }

        #endregion

        #endregion
    }
}
