using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.CreateNewPassword
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class CreateNewPasswordValidator : AbstractValidator<CreateNewPasswordRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.CreateNewPassword.CreateNewPasswordValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public CreateNewPasswordValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.UserToken)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.UserToken)));

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Password)))
                .Password(appConfig.PasswordMinimumLength);

            RuleFor(x => x.RepeatPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.RepeatPassword)));

            RuleFor(x => x.Password)
                .Equal(x => x.RepeatPassword)
                .When(x => !string.IsNullOrWhiteSpace(x.Password))
                .WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNotMatch(nameof(x.Password), nameof(x.RepeatPassword)));
        }

        #endregion
    }
}
