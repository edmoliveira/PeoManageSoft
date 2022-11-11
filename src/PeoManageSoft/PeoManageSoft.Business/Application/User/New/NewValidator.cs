using FluentValidation;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class NewValidator : AbstractValidator<NewRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public NewValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.RoleId)
            .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.RoleId)));

            RuleFor(x => x.RoleId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.RoleId)))
                .Must((x, roleId) => Enumerators.UserRoleIsDefined(roleId)).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNoExists(nameof(x.RoleId)));

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

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Name)));

            RuleFor(x => x.ShortName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.ShortName)));

            RuleFor(x => x.TitleId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.TitleId)));

            RuleFor(x => x.DepartmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.DepartmentId)));

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Email)))
                .EmailAddress().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageInvalidEmail(nameof(x.Email)));
        }

        #endregion
    }
}
