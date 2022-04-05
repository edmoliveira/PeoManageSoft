namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Mapping to a database table
    /// </summary>
    public interface IEntity
    {
        #region Properties

        /// <summary>
        /// Unique identifier
        /// </summary>
        long Id { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Get the parameters to the insert sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        object GetInsertParameters();
        /// <summary>
        /// Get the parameters to the update sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        object GetUpdateParameters();

        #endregion
    }
}
