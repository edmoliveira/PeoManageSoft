using FluentValidation;

namespace PeoManageSoft.Business.Application.User.Delete
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal class DeleteValidator : AbstractValidator<DeleteRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Delete.DeleteValidator class.
        /// </summary>
        public DeleteValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }

        #endregion
    }
}
