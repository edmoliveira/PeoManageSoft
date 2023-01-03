using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.Read
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ReadValidator : AbstractValidator<ReadRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Read.ReadValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ReadValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)));
        }

        #endregion
    }
}
