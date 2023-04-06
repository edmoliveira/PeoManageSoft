using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.Role.Change;
using PeoManageSoft.Business.Application.Role.Delete;
using PeoManageSoft.Business.Application.Role.New;
using PeoManageSoft.Business.Application.Role.Read;
using PeoManageSoft.Business.Application.Role.ReadAll;
using PeoManageSoft.Business.Application.Role.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Role.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Role
{
    /// <summary>
    /// Extension methods to add services from role application
    /// </summary>
    internal static class RoleApplicationDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds role application services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRoleApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRoleApplicationFacade, RoleApplicationFacade>();
            services.AddScoped<IChangeApplication, ChangeApplication>();
            services.AddScoped<IChangeValidation, ChangeValidation>();
            services.AddScoped<IDeleteApplication, DeleteApplication>();
            services.AddScoped<IDeleteValidation, DeleteValidation>();
            services.AddScoped<INewApplication, NewApplication>();
            services.AddScoped<INewValidation, NewValidation>();
            services.AddScoped<IReadApplication, ReadApplication>();
            services.AddScoped<IReadValidation, ReadValidation>();
            services.AddScoped<IReadAllApplication, ReadAllApplication>();
            services.AddScoped<IReadAllWithPaginationApplication, ReadAllWithPaginationApplication>();
            services.AddScoped<ISearchWithPaginationApplication, SearchWithPaginationApplication>();
        }

        /// <summary>
        /// Adds role application validation to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRoleApplicationValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ChangeRequest>, ChangeValidator>();
            services.AddScoped<IValidator<DeleteRequest>, DeleteValidator>();
            services.AddScoped<IValidator<NewRequest>, NewValidator>();
            services.AddScoped<IValidator<ReadRequest>, ReadValidator>();
            services.AddScoped<IValidator<ReadAllWithPaginationRequest>, ReadAllWithPaginationValidator>();
            services.AddScoped<IValidator<SearchWithPaginationRequest>, SearchWithPaginationValidator>();
        }

        #endregion

        #endregion
    }
}
