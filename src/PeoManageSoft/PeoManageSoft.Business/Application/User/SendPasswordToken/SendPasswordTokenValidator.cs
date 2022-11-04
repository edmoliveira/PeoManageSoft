using FluentValidation;

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
        public SendPasswordTokenValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();                
        }

        #endregion
    }
}
