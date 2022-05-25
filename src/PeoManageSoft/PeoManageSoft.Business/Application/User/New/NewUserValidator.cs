using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal class NewUserValidator: AbstractValidator<NewUserRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewUserValidator class.
        /// </summary>
        public NewUserValidator()
        {
            RuleFor(x => x.Role).IsInEnum();
            RuleFor(x => x.Login)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
