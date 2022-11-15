using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Title.Change
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ChangeValidator : AbstractValidator<ChangeRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.Change.ChangeValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ChangeValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)));

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Name)));
        }

        #endregion
    }
}
