using FluentValidation;
using PeoManageSoft.Business.Domain.Services.Functions.Role;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Role.New
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    internal sealed class NewValidation : BaseValidation<NewRequest>, INewValidation
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.New.NewValidation class.
        /// </summary>
        /// <param name="functionFacade">Role function facade that provides a simplified interface.</param>
        /// <param name="appConfig">Application Configuration</param>
        public NewValidation(
            IRoleFunctionFacade functionFacade,
            IAppConfig appConfig
        )
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Name)))
                .MustAsync(async (name, cancellation) =>
                {
                    bool exists = await functionFacade.NameExistsAsync(name).ConfigureAwait(false);

                    return !exists;
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageAlreadyExists(nameof(x.Name)));
        }

        #endregion
    }
}
