using FluentValidation;

namespace PeoManageSoft.Business.Application.User.Read
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class ReadValidator : AbstractValidator<ReadRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.ReadValidator class.
        /// </summary>
        public ReadValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }

        #endregion
    }
}
