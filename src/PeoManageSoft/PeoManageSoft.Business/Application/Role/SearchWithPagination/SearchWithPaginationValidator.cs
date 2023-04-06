using FluentValidation;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Application.Role.SearchWithPagination
{
    /// <summary>
    /// Object validator
    /// </summary>
    internal sealed class SearchWithPaginationValidator : AbstractValidator<SearchWithPaginationRequest>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.SearchWithPagination.SearchWithPaginationValidator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public SearchWithPaginationValidator(IAppConfig appConfig)
        {
            RuleFor(x => x.Page)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageGreaterThan(nameof(x.Page), 0));

            RuleFor(x => x.QuantityPerPage)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageGreaterThan(nameof(x.QuantityPerPage), 0));

            RuleFor(x => x.OrderByFields)
                .Cascade(CascadeMode.Stop)
                .Must(x => x.Any()).WithMessage(x => appConfig.MessagesCatalogResource.GetMessageGreaterThan(nameof(x.OrderByFields), 0));
        }

        #endregion
    }
}
