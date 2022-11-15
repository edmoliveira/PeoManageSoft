using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Department.New
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class NewValidator : AbstractValidator<NewRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.New.NewValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public NewValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Name)));
        }

        #endregion
    }
}
