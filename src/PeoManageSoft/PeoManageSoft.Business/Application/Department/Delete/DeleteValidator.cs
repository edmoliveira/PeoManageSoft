using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Department.Delete
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class DeleteValidator : AbstractValidator<DeleteRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.Delete.DeleteValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public DeleteValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)));
        }

        #endregion
    }
}
