using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Functionality to fetch data from datareader based on entity settings
    /// </summary>
    internal interface IDataReaderGetValue
    {
        #region Methods

        /// <summary>
        /// Gets Value from the DataReader
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="entityField">Entity fields types</param>
        /// <returns>Type value</returns>
        T GetValue<T>(object entityField);

        /// <summary>
        /// Gets the DataReader object.
        /// </summary>
        /// <returns>An data reader that can be used to iterate over the results of the SQL query.</returns>
        IDataReader GetDataReader();

        #endregion
    }
}
