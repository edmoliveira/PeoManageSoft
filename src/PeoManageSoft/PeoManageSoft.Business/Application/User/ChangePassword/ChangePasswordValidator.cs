using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.ChangePassword
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ChangePassword.ChangePasswordValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ChangePasswordValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.OldPassword)
            .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.OldPassword)));

            RuleFor(x => x.NewPassword)
            .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.NewPassword)))
                .Password(appConfig.PasswordMinimumLength);

            RuleFor(x => x.RepeatPassword)
            .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.RepeatPassword)));

            RuleFor(x => x.NewPassword)
                .Equal(x => x.RepeatPassword)
                .When(x => !string.IsNullOrWhiteSpace(x.NewPassword))
                .WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNotMatch(nameof(x.NewPassword), nameof(x.RepeatPassword)));
        }

        #endregion
    }
}
