using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.Change
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ChangeValidator : AbstractValidator<ChangeRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Change.ChangeValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ChangeValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)));

            RuleFor(x => x.Role)
                .Cascade(CascadeMode.Stop)
                .IsInEnum().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Role)))
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Role)));

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
