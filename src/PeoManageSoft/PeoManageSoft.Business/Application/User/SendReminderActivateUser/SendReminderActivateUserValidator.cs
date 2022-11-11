using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.SendReminderActivateUser
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class SendReminderActivateUserValidator : AbstractValidator<SendReminderActivateUserRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SendReminderActivateUser.SendReminderActivateUserValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public SendReminderActivateUserValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Url)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Url)))
                .Uri().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageInvalidUri(nameof(x.Url)));

            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)));
        }

        #endregion
    }
}
