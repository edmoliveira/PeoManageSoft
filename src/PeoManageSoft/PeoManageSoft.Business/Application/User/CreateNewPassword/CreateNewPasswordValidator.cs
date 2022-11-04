using FluentValidation;

namespace PeoManageSoft.Business.Application.User.CreateNewPassword
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class CreateNewPasswordValidator : AbstractValidator<CreateNewPasswordRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.CreateNewPassword.CreateNewPasswordValidator class.
        /// </summary>
        public CreateNewPasswordValidator()
        {
            RuleFor(x => x.UserToken)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
