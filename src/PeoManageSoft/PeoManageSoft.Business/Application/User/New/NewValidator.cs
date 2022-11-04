using FluentValidation;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class NewValidator : AbstractValidator<NewRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewValidator class.
        /// </summary>
        public NewValidator()
        {
            RuleFor(x => x.Role).IsInEnum();
            RuleFor(x => x.Login)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
