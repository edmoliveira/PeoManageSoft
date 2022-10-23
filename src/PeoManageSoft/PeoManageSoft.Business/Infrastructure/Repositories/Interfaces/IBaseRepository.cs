using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    internal interface IBaseRepository<TEntity>
    {
        #region Methods

        /// <summary>
        /// Creates the record in the <see cref="TEntity"/> table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity"><see cref="TEntity"/>Entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task InsertAsync(IScope scope, TEntity entity);
        /// <summary>
        /// Updates the record from the <see cref="TEntity"/> table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity"><see cref="TEntity"/> entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task UpdateAsync(IScope scope, TEntity entity);
        /// Deteles the record from the <see cref="TEntity"/> table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id"><see cref="TEntity"/> identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task DeleteAsync(IScope scope, long id);
        /// Determines whether the specified <see cref="TEntity"/> table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id"><see cref="TEntity"/> identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// Returns true if the record exists in the table
        /// </returns>
        Task<bool> ExistsAsync(IScope scope, long id);
        /// <summary>
        /// Query the record in the <see cref="TEntity"/> table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id"><see cref="TEntity"/> identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the <see cref="TEntity"/> entity.
        /// </returns>
        Task<TEntity> SelectByIdAsync(IScope scope, long id);
        /// <summary>
        /// Query records in the <see cref="TEntity"/> table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the <see cref="TEntity"/> entity collection.
        /// </returns>
        Task<IEnumerable<TEntity>> SelectAllAsync(IScope scope);
        /// <summary>
        /// Validates whether inserting into the <see cref="TEntity"/> table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity"><see cref="TEntity"/> entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        Task<IEnumerable<string>> ValidateInsertAsync(IScope scope, TEntity entity);
        /// <summary>
        /// Validates whether updating into the <see cref="TEntity"/> table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity"><see cref="TEntity"/> entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        Task<IEnumerable<string>> ValidateUpdateAsync(IScope scope, TEntity entity);

        #endregion
    }
}
