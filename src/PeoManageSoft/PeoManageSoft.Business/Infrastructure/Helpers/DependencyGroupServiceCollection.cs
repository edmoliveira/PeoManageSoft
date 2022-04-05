using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Filters;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Tokens;

using repositories = PeoManageSoft.Business.Infrastructure.Repositories;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Extension methods for adding services
    /// </summary>
    public static class DependencyGroupServiceCollection
    {
        #region Methods

        #region public

        /// <summary>
        /// Method to add a services group to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <param name="allowSpecificOrigins">Allow specific origins.</param>
        /// <param name="apiVersion">Api version</param>
        /// <param name="loggerType">Logger Type</param>
        /// <exception cref="ProviderServiceNotFoundException">Represents errors that occur when service provider tries to get a service.</exception>
        public static void AddDependencyGroup(this IServiceCollection services, IConfiguration configuration, string allowSpecificOrigins, Version apiVersion, Type loggerType)
        {
            AppConfig appConfig = configuration.GetSection("AppConfig").Get<AppConfig>();

            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped(c => (ISetApplicationContext)c.GetService<IApplicationContext>());

            AddMapperConfiguration(services);

            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IContentScope, ScopeOrm>();
            services.AddScoped<IConnection, Connection>();
            services.AddScoped<ITransactionScope, TransactionScopeOrm>();

            services.AddSingleton<IAppConfig>(c => appConfig);

            AddApplicationServices(services);
            AddDomainServices(services);
            AddRepositoryServices(services);

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.OperationFilter<HeaderParameterOperationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
                });

                foreach (IConfigurationOpenApiInfo item in appConfig.Documents)
                {
                    c.SwaggerDoc(item.DocumentName, new OpenApiInfo
                    {
                        Version = apiVersion.ToString(2),
                        Title = item.Title,
                        Description = item.Description,
                        TermsOfService = new Uri(appConfig.TermsOfServiceOpenApi),
                        Contact = new OpenApiContact
                        {
                            Name = appConfig.NameOpenApiContact,
                            Email = appConfig.EmailOpenApiContact,
                            Url = new Uri(appConfig.UrlOpenApiContact),
                        },
                        License = new OpenApiLicense
                        {
                            Name = appConfig.NameOpenApiLicense,
                            Url = new Uri(appConfig.UrlOpenApiLicense),
                        }
                    });
                }
            });
            services.AddSwaggerGenNewtonsoftSupport();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            services.AddMvcCore(options => options.EnableEndpointRouting = false)
                    .AddCors(options =>
                    {
                        options.AddPolicy(name: allowSpecificOrigins,
                                          builder =>
                                          {
                                              builder
                                                .WithMethods(appConfig.AllowedMethods)
                                                .WithHeaders(appConfig.AllowedHeaders)
                                                .AllowCredentials();

                                              if (appConfig.AllowedOrigins?.Length > 0)
                                              {
                                                  builder
                                                    .WithOrigins(appConfig.AllowedOrigins);
                                              }
                                          });
                    });

            services
                .AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpResponseExceptionFilter));
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddApiVersioning(version =>
            {
                version.DefaultApiVersion = new ApiVersion(apiVersion.Major, apiVersion.Minor);
                version.AssumeDefaultVersionWhenUnspecified = true;
                version.ReportApiVersions = true;
                version.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });

            services.AddSingleton<IPostConfigureOptions<NetAuthenticationOptions>, NetAuthenticationPostConfigureOptions>();
            services.AddSingleton<ITokenCache, TokenCache>();
            services.AddSingleton<INetSecurityTokenHandler, NetSecurityTokenHandler>();
            services.AddSingleton<ITokenJwt, TokenNet>();

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = appConfig.TokenCacheAddress;
                option.InstanceName = appConfig.TokenCacheInstance;
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();


            if (serviceProvider.GetService(typeof(ILoggerFactory))
                    is not ILoggerFactory loggerFactory)
            {
                throw new ProviderServiceNotFoundException(nameof(ILoggerFactory));
            }

            ILogger logger = loggerFactory.CreateLogger(loggerType);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = NetBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = NetBearerDefaults.AuthenticationScheme;
            })
            .AddNetBearer(options =>
            {
                options.ValidTokenAsync = async (token, scheme) =>
                {
                    if (serviceProvider.GetService(typeof(INetSecurityTokenHandler)) is not INetSecurityTokenHandler handler)
                    {
                        throw new ProviderServiceNotFoundException(nameof(INetSecurityTokenHandler));
                    }

                    if (serviceProvider.GetService(typeof(ITokenCache))
                            is not ITokenCache tokenCache)
                    {
                        throw new ProviderServiceNotFoundException(nameof(ITokenCache));
                    }

                    NetResultValidToken result = await handler.ValidTokenAsync(token, appConfig.AuthTokenSecrect, tokenCache).ConfigureAwait(false);

                    if (!result.Sucess)
                    {
                        logger.DebugIsEnabled(() => string.Concat("ValidTokenAsync Error: ", result.Exception?.Message));
                    }

                    return result;
                };
            });
        }

        #endregion

        #region private

        /// <summary>
        ///  Adds services of the type Application in TService with an implementation type specified in 
        ///  TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        private static void AddApplicationServices(IServiceCollection services)
        {
            //services.AddScoped<IUserApplication, UserApplication>();
            //services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            //services.AddScoped<IEnvironmentApplication, EnvironmentApplication>();
        }

        /// <summary>
        ///  Adds services of the type Domain in TService with an implementation type specified in 
        ///  TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        private static void AddDomainServices(IServiceCollection services)
        {
            //services.AddScoped<IEnvironmentService, EnvironmentService>();
            //services.AddScoped<IUserService, UserService>();
        }

        /// <summary>
        ///  Adds services of the type Repository in TService with an implementation type specified in 
        ///  TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        private static void AddRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<repositories.User.IUserRepository, repositories.User.UserRepository>();
        }

        /// <summary>
        /// Adds object mappers to configuration source for generated mappers
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        private static void AddMapperConfiguration(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(c =>
            {
                //c.AddProfile<EnvironmentMapper>();
                //c.AddProfile<UserMapper>();
            });

            configuration.CreateMapper();

            services.AddSingleton<IMapper>(c => new Mapper(configuration));
        }

        #endregion

        #endregion
    }
}
