using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.ActivateUser
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ActivateUserValidator : AbstractValidator<ActivateUserRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ActivateUser.ActivateUserValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ActivateUserValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.UserToken)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.UserToken)));
        }

        #endregion
    }
}
