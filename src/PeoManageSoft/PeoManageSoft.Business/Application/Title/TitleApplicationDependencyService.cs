using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.Title.Change;
using PeoManageSoft.Business.Application.Title.Delete;
using PeoManageSoft.Business.Application.Title.New;
using PeoManageSoft.Business.Application.Title.Read;
using PeoManageSoft.Business.Application.Title.ReadAll;
using PeoManageSoft.Business.Application.Title.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Title.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Title
{
    /// <summary>
    /// Extension methods to add services from title application
    /// </summary>
    internal static class TitleApplicationDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds title application services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddTitleApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITitleApplicationFacade, TitleApplicationFacade>();
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
        /// Adds title application validation to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddTitleApplicationValidation(this IServiceCollection services)
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
