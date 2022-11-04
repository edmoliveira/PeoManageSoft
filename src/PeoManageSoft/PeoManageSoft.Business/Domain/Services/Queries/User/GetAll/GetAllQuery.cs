﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAll
{
    /// <summary>
    /// Get all user query.
    /// </summary>
    internal sealed class GetAllQuery : IGetAllQuery
    {
        #region Fields

        /// <summary>
        /// Data Access Layer
        /// </summary>
        private readonly IUserRepository _repository;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<GetAllQuery> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetAll.GetAllQuery class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public GetAllQuery(
                IUserRepository repository,
                IMapper mapper,
                ILogger<GetAllQuery> logger
            )
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<IEnumerable<GetResponse>> ExecuteAsync(IScope scope)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            IEnumerable<UserEntity> collection = await _repository.SelectAllAsync(scope).ConfigureAwait(false);

            IEnumerable<GetResponse> response = _mapper.Map<IEnumerable<GetResponse>>(collection);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
