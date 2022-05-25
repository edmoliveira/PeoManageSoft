using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Mapping to a database table
    /// </summary>
    internal interface IEntity
    {
        #region Properties

        /// <summary>
        /// Unique identifier
        /// </summary>
        long Id { get; }
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        string RequestId { get; }
        /// <summary>
        /// User who created the record
        /// </summary>
        string CreationUser { get; }
        /// <summary>
        /// Record creation date and time
        /// </summary>
        DateTime? CreationDate { get; }
        /// <summary>
        /// User who updated the record
        /// </summary>
        string UpdatedUser { get; }
        /// <summary>
        /// Record update date and time
        /// </summary>
        DateTime? UpdatedDate { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the unique identifier
        /// </summary>
        /// <param name="id">The unique identifier</param>
        void SetId(long id);
        /// <summary>
        /// Get the parameters to the insert sql statement
        /// </summary>
        /// <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object GetInsertParameters(IApplicationContext applicationContext);
        /// <summary>
        /// Get the parameters to the update sql statement
        /// </summary>
        ///  <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object GetUpdateParameters(IApplicationContext applicationContext);

        #endregion
    }
}
