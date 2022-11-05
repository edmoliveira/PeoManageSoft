using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.SendPasswordToken
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class SendPasswordTokenValidator : AbstractValidator<SendPasswordTokenRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SendPasswordToken.SendPasswordTokenValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public SendPasswordTokenValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Url)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Url)))
                .Uri().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageInvalidUri(nameof(x.Url)));

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Email)))
                .EmailAddress().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageInvalidEmail(nameof(x.Email)));


        }

        #endregion
    }
}
