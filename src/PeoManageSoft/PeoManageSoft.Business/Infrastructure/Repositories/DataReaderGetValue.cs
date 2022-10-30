using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Functionality to fetch data from datareader based on entity settings
    /// </summary>
    internal sealed class DataReaderGetValue<TEntity, TEntityField> : IDataReaderGetValue
    {
        #region Fields

        /// <summary>
        /// Gets a function to look up the entity property value.
        /// </summary>
        private readonly Func<object, IDataReader, object> _searchValueFunc;
        /// <summary>
        /// An data reader that can be used to iterate over the results of the SQL query.
        /// </summary>
        private readonly IDataReader _dataReader;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.DataReaderGetValue class.
        /// </summary>
        /// <param name="entityConfig">Entity configuration.</param>
        /// <param name="dataReader">An data reader that can be used to iterate over the results of the SQL query.</param>
        public DataReaderGetValue(
            IBaseEntityConfig<TEntity, TEntityField> entityConfig,
            IDataReader dataReader)
        {
            _searchValueFunc = entityConfig.GetFuncSearchValue();
            _dataReader = dataReader;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets Value from the DataReader
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="entityField">Entity fields types</param>
        /// <returns>Type value</returns>
        public T GetValue<T>(object entityField)
        {
            return (T)_searchValueFunc(entityField, _dataReader);
        }

        /// <summary>
        /// Gets the DataReader object.
        /// </summary>
        /// <returns>An data reader that can be used to iterate over the results of the SQL query.</returns>
        public IDataReader GetDataReader()
        {
            return _dataReader;
        }

        #endregion

        #endregion
    }
}
