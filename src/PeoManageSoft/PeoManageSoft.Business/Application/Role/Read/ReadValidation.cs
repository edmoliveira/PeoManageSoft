using FluentValidation;
using PeoManageSoft.Business.Domain.Services.Functions.Role;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Role.Read
{
    /// <summary>
    /// Application layer validation object
    /// </summary>
    internal sealed class ReadValidation : BaseValidation<ReadRequest>, IReadValidation
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.Read.ReadValidation class.
        /// </summary>
        /// <param name="functionFacade">Role function facade that provides a simplified interface.</param>
        /// <param name="appConfig">Application Configuration</param>
        public ReadValidation(
            IRoleFunctionFacade functionFacade,
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
                }).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(x.Id)));
        }

        #endregion
    }
}
