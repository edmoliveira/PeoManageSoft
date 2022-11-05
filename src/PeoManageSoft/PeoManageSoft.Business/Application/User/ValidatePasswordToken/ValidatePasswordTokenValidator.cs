using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ValidatePasswordTokenValidator : AbstractValidator<ValidatePasswordTokenRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ValidatePasswordToken.ValidPasswordTokenValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ValidatePasswordTokenValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.PasswordToken)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.PasswordToken)));
        }

        #endregion
    }
}
