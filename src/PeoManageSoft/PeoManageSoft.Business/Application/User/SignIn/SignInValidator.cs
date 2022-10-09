using FluentValidation;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal class SignInValidator : AbstractValidator<SignInRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SignIn.SignInValidator class.
        /// </summary>
        public SignInValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
