using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models;
using PeoManageSoft.Business.Domain.Services.Functions.Department;
using PeoManageSoft.Business.Domain.Services.Functions.Title;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.ResourcesPolicySettings.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// New user application layer.
    /// </summary>
    internal sealed class NewApplication : INewApplication
    {
        #region Fields

        /// <summary>
        /// Application layer validation object.
        /// </summary>
        private readonly INewValidation _newValidation;
        /// <summary>
        ///  Handles all commands to add the user.
        /// </summary>
        private readonly IAddHandler _addHandler;
        /// <summary>
        /// Handles all queries to get the role resources.
        /// </summary>
        private readonly IGetResourcesHandler _getResourcesHandler;
        /// <summary>
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
        /// <summary>
        /// Title function facade that provides a simplified interface.
        /// </summary>
        private readonly ITitleFunctionFacade _titleFunctionFacade;
        /// <summary>
        /// Department function facade that provides a simplified interface.
        /// </summary>
        private readonly IDepartmentFunctionFacade _departmentFunctionFacade;
        /// <summary>
        ///  Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Resources policy configuration.
        /// </summary>
        private readonly IResourcesPolicyConfiguration _resourcesPolicyConfiguration;
        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<NewApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewApplication class.
        /// </summary>
        /// <param name="newValidation">Application layer validation object.</param>
        /// <param name="addHandler">Handles all commands to add the user.</param>
        /// <param name="getResourcesHandler">Handles all queries to get the role resources.</param>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="titleFunctionFacade">Title function facade that provides a simplified interface.</param>
        /// <param name="departmentFunctionFacade">Department function facade that provides a simplified interface.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="resourcesPolicyConfiguration">Resources policy configuration.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public NewApplication(
                INewValidation newValidation,
                IAddHandler addHandler,
                IGetResourcesHandler getResourcesHandler,
                IUserFunctionFacade functionFacade,
                ITitleFunctionFacade titleFunctionFacade,
                IDepartmentFunctionFacade departmentFunctionFacade,
                ITokenJwt tokenJwt,
                IResourcesPolicyConfiguration resourcesPolicyConfiguration,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<NewApplication> logger
            )
        {
            _newValidation = newValidation;
            _addHandler = addHandler;
            _getResourcesHandler = getResourcesHandler;
            _functionFacade = functionFacade;
            _titleFunctionFacade = titleFunctionFacade;
            _departmentFunctionFacade = departmentFunctionFacade;
            _tokenJwt = tokenJwt;
            _resourcesPolicyConfiguration = resourcesPolicyConfiguration;
            _appConfig = appConfig;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer of the new user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<NewResponse> HandleAsync(NewRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            await _newValidation.RunValidationAsync(request).ConfigureAwait(false);

            AddRequest commandRequest = _mapper.Map<AddRequest>(request);

            var policies = new List<UserPolicy>();

            var roleResources = await _getResourcesHandler.HandleAsync(new GetResourcesRequest { RoleId = commandRequest.RoleId }).ConfigureAwait(false);

            foreach (var resource in _resourcesPolicyConfiguration.GetResources())
            {
                UserPolicy userPolicy = new()
                {
                    ResourceName = resource
                };

                var roleResource = roleResources.Where(r => string.Equals(r.ResourceName, resource, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (roleResource != null)
                {
                    userPolicy.Permissions = roleResource.Permissions;
                }
                else
                {
                    userPolicy.Permissions = new Grant(false, false, false, false);
                }

                policies.Add(userPolicy);
            }

            commandRequest.Policies = policies;
            commandRequest.Password = _tokenJwt.EncryptPassword(request.Password);
            commandRequest.IsActive = false;

            NewResponse response = _mapper.Map<NewResponse>(
                await _addHandler.HandleAsync(commandRequest).ConfigureAwait(false)
            );

            _ = _functionFacade.SendEmailToActiveUserAsync(new SendEmailToActiveUserFunctionRequest
            {
                Email = request.Email,
                Url = request.Url,
                UserToken = _tokenJwt.CreateUserToken(response.Id, commandRequest.Email)
            })
            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
