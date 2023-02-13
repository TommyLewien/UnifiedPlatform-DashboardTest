using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Discom.UP.Backend.UpDash.Rest.Entities;


namespace Discom.UP.Backend.UpDash.Rest.DependencyInjection
{

    /// <summary>
    /// Service Registration for Results Assembly
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <inheritdoc/>
        public static IServiceCollection AddRestLibServices(this IServiceCollection services, IConfiguration configuration)
        {

            // need to install nuget Microsoft.Extensions.Options.ConfigurationExtensions !!!
            services.Configure<AuthenticationHandlerSettings>(configuration.GetSection(AuthenticationHandlerSettings.SectionName));
            services.Configure<UpConnectionUrlSettings>(configuration.GetSection(UpConnectionUrlSettings.SectionName));
            return services;
        }
    }
}

