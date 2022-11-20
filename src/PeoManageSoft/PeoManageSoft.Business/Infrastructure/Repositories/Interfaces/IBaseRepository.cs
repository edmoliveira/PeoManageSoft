using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal interface IBaseRepository<TEntity, TEntityField>
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
        /// <summary>
        /// Modifies partial data that must be updated without modifying the entire data and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="fields"><see cref="TEntityField"/> Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task PatchAsync(IScope scope, IEnumerable<Field<TEntityField>> fields, long id);
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
        /// Determines whether the specified entity table contains the record that matches the rules.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// Returns true if the record exists in the table
        /// </returns>
        Task<bool> ExistsAsync(IScope scope, IRule<TEntityField> rule);
        /// <summary>
        /// Query the record in the <see cref="TEntity"/> table by id and asynchronously using Task.
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
        /// Query the record in the <see cref="TEntity"/> table by rules and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the <see cref="TEntity"/> entity collection.
        /// </returns>
        Task<IEnumerable<TEntity>> SelectByRulesAsync(IScope scope, IRule<TEntityField> rule);
        /// <summary>
        /// Query records in the <see cref="TEntity"/> table with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="page">Current page</param>
        /// <param name="quantityPerPage">Quantity per page</param>
        /// <param name="orderBy">OrderBy sql command</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the <see cref="TEntity"/> entity collection.
        /// </returns>
        Task<IEnumerable<TEntity>> SelectAllWithPaginationAsync(IScope scope, int page, int quantityPerPage, OrderBy<TEntityField> orderBy);
        /// <summary>
        /// Query the record in the <see cref="TEntity"/> table with pagination by rules and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="page">Current page</param>
        /// <param name="quantityPerPage">Quantity per page</param>
        /// <param name="orderBy">OrderBy sql command</param>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the <see cref="TEntity"/> entity collection.
        /// </returns>
        Task<IEnumerable<TEntity>> SelectByRulesWithPaginationAsync(IScope scope, int page, int quantityPerPage, OrderBy<TEntityField> orderBy, IRule<TEntityField> rule);

        #endregion
    }
}
