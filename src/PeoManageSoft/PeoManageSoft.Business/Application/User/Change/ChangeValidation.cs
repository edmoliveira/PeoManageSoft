using FluentValidation;
using PeoManageSoft.Business.Domain.Services.Functions.Department;
using PeoManageSoft.Business.Domain.Services.Functions.Title;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.User.Change
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    internal sealed class ChangeValidation : BaseValidation<ChangeRequest>, IChangeValidation
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewValidation class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="titleFunctionFacade">Title function facade that provides a simplified interface.</param>
        /// <param name="departmentFunctionFacade">Department function facade that provides a simplified interface.</param>
        /// <param name="appConfig">Application Configuration</param>
        public ChangeValidation(
            IUserFunctionFacade functionFacade,
            ITitleFunctionFacade titleFunctionFacade,
            IDepartmentFunctionFacade departmentFunctionFacade,
            IAppConfig appConfig
        )
        {
            RuleFor(x => x.TitleId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.TitleId)))
                .MustAsync(async (titleId, cancellation) =>
                {
                    bool exists = await titleFunctionFacade.ExistsAsync(titleId).ConfigureAwait(false);

                    return exists;
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNoExists(nameof(x.TitleId)));

            RuleFor(x => x.DepartmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageRequired(nameof(x.DepartmentId)))
                .MustAsync(async (departmentId, cancellation) =>
                {
                    bool exists = await departmentFunctionFacade.ExistsAsync(departmentId).ConfigureAwait(false);

                    return exists;
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNoExists(nameof(x.DepartmentId)));
        }

        #endregion
    }
}
