using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.Department.Change;
using PeoManageSoft.Business.Application.Department.Delete;
using PeoManageSoft.Business.Application.Department.New;
using PeoManageSoft.Business.Application.Department.Read;
using PeoManageSoft.Business.Application.Department.ReadAll;
using PeoManageSoft.Business.Application.Department.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Department.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Department
{
    /// <summary>
    /// Extension methods to add services from department application
    /// </summary>
    internal static class DepartmentApplicationDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds department application services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddDepartmentApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentApplicationFacade, DepartmentApplicationFacade>();
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
        /// Adds department application validation to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddDepartmentApplicationValidation(this IServiceCollection services)
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
