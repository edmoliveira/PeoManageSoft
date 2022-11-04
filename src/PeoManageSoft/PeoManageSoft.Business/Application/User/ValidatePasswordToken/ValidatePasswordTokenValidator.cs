using FluentValidation;

namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ValidatePasswordTokenValidator : AbstractValidator<ValidatePasswordTokenRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ValidatePasswordToken.ValidPasswordTokenValidator class.
        /// </summary>
        public ValidatePasswordTokenValidator()
        {
            RuleFor(x => x.PasswordToken)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
