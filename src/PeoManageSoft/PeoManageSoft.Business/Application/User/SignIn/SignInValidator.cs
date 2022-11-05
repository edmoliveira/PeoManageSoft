using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class SignInValidator : AbstractValidator<SignInRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SignIn.SignInValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public SignInValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Login)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Login)));

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Password)));
        }

        #endregion
    }
}
