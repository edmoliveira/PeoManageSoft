﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using System.Data;
using static PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Title encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class TitleRepository : BaseRepository, ITitleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public TitleRepository(
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            IMapper mapper,
            ILogger<TitleRepository> logger)
            : base(dbContext, applicationContext, provider, mapper, logger)
        {
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Deteles the record from the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Title identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(IScope scope, long id)
        {
            string methodName = nameof(DeleteAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                GetDeleteSqlStatement(id)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        /// Determines whether the specified title table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// Returns true if the record exists in the table
        /// </returns>
        public async Task<bool> ExistsAsync(IScope scope, long id)
        {
            string methodName = nameof(ExistsAsync);

            Logger.LogBeginInformation(methodName);

            bool result = await ExecuteScalarAsync<bool>(
                scope, () =>
                GetExistsByIdSqlStatement(id)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Creates the record in the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Title entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(InsertAsync);

            Logger.LogBeginInformation(methodName);

            IEntity ientity = entity;

            long id = await ExecuteScalarAsync<long>(
                scope, () =>
                GetInsertSqlStatement(Provider, entity, ApplicationContext)
            ).ConfigureAwait(false);

            ientity.SetId(id);

            Logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Query records in the title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the user entity collection.
        /// </returns>
        public async Task<IEnumerable<TitleEntity>> SelectAllAsync(IScope scope)
        {
            string methodName = nameof(SelectAllAsync);

            Logger.LogBeginInformation(methodName);

            var collection = new List<TitleEntity>();

            await ExecuteReaderAsync(dataReader =>
            {
                collection.Add(SetEntity(dataReader));
            }, scope, () => GetSelectAllSqlStatement()).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return collection;
        }

        /// <summary>
        /// Query the record in the title table by id and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user entity.
        /// </returns>
        public async Task<TitleEntity> SelectByIdAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            Logger.LogBeginInformation(methodName);

            TitleEntity entity = null;

            await ExecuteReaderAsync(dataReader =>
            {
                entity = SetEntity(dataReader);
            }, scope, () => GetSelectByIdSqlStatement(Provider, id)).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return entity;
        }

        /// <summary>
        /// Query the record in the user table by rules and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>IEnumerable[TEntity]</returns>
        public async Task<IEnumerable<TitleEntity>> SelectByRulesAsync(IScope scope, IRule<EntityField> rule)
        {
            string methodName = nameof(SelectByRulesAsync);

            Logger.LogBeginInformation(methodName);

            var collection = new List<TitleEntity>();

            await ExecuteReaderAsync(dataReader =>
            {
                collection.Add(SetEntity(dataReader));
            }, scope, () => GetSelectByRulesSqlStatement(Provider, rule)).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return collection;
        }

        /// <summary>
        /// Updates the record from the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Title entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(UpdateAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                TitleEntityConfig.GetUpdateSqlStatement(Provider, entity, ApplicationContext)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Modifies partial data that must be updated without modifying the entire data and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="fields">Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task PatchAsync(IScope scope, IEnumerable<Field<EntityField>> fields, long id)
        {
            string methodName = nameof(PatchAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                GetPatchSqlStatement(Provider, fields, id, ApplicationContext)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        #endregion

        #region private

        /// <summary>
        /// Sets the entity
        /// </summary>
        /// <param name="dataReader">An data reader that can be used to iterate over the results of the SQL query.</param>
        /// <returns>Entity</returns>
        private TitleEntity SetEntity(IDataReader dataReader)
        {
            return Mapper.Map<TitleEntity>(dataReader);
        }

        #endregion

        #endregion
    }
}
