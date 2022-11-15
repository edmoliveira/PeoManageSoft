using FluentValidation;
using PeoManageSoft.Business.Domain.Services.Functions.Title;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Title.Delete
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    internal sealed class DeleteValidation : BaseValidation<DeleteRequest>, IDeleteValidation
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.Delete.DeleteValidation class.
        /// </summary>
        /// <param name="functionFacade">Title function facade that provides a simplified interface.</param>
        /// <param name="appConfig">Application Configuration</param>
        public DeleteValidation(
            ITitleFunctionFacade functionFacade,
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
        }

        #endregion
    }
}
