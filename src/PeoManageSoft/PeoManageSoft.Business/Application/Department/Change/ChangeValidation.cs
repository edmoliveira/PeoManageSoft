using FluentValidation;
using PeoManageSoft.Business.Domain.Services.Functions.Department;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Department.Change
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    internal sealed class ChangeValidation : BaseValidation<ChangeRequest>, IChangeValidation
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.New.NewValidation class.
        /// </summary>
        /// <param name="functionFacade">Department function facade that provides a simplified interface.</param>
        /// <param name="appConfig">Application Configuration</param>
        public ChangeValidation(
            IDepartmentFunctionFacade functionFacade,
            IAppConfig appConfig
        )
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Id)))
                .MustAsync(async (id, cancellation) =>
                {
                    bool exists = await functionFacade.ExistsAsync(id).ConfigureAwait(false);

                    return exists;
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNoExists(nameof(x.Id)));

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.Name)))
                .MustAsync(async (x, name, cancellation) =>
                {
                    bool exists = await functionFacade.NameExistsAsync(name, x.Id).ConfigureAwait(false);

                    return !exists;
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageAlreadyExists(nameof(x.Name)));
        }

        #endregion
    }
}
