using FluentValidation;

namespace PeoManageSoft.Business.Application.User.Change
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal class ChangeValidator : AbstractValidator<ChangeRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Change.ChangeValidator class.
        /// </summary>
        public ChangeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }

        #endregion
    }
}
