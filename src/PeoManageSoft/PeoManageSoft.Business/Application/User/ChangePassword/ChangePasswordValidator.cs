using FluentValidation;

namespace PeoManageSoft.Business.Application.User.ChangePassword
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ChangePassword.ChangePasswordValidator class.
        /// </summary>
        public ChangePasswordValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
