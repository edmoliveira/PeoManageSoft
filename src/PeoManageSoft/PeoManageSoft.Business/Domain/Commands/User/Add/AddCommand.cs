﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Net;

namespace PeoManageSoft.Business.Domain.Commands.User.Add
{
    /// <summary>
    /// Add user command.
    /// </summary>
    internal class AddCommand : IAddCommand
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
        private readonly ILogger<AddHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Commands.User.Add.AddCommand class.
        /// </summary>
        /// <param name="repository">Data Access Layer</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public AddCommand(
                IUserRepository repository,
                IMapper mapper,
                ILogger<AddHandler> logger
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
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request for the add user command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the add user command.
        /// </returns>
        public async Task<AddResponse> ExecuteAsync(IScope scope, AddRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            bool titleExists = await _repository.ExistsAsync(scope, request.TitleId).ConfigureAwait(false);
            bool departmentExists = await _repository.ExistsAsync(scope, request.DepartmentId).ConfigureAwait(false);

            if (!titleExists || !departmentExists)
            {
                List<string> messages = new();

                messages
                    .AddIf(() => !titleExists, "Title not found!")
                    .AddIf(() => !departmentExists, "Department not found!");

                throw new RequestException(HttpStatusCode.NotFound, messages);
            }

            UserEntity entity = _mapper.Map<UserEntity>(request);

            await _repository.InsertAsync(scope, entity).ConfigureAwait(false);

            AddResponse response = _mapper.Map<AddResponse>(entity);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
