using Discom.UP.Backend.UpDash.Interfaces.Infrastructure;
using Discom.UP.Backend.UpDash.Rest.DependencyInjection;

namespace Discom.UP.Backend.UpDash.Init
{
    public static class Startup
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

            // Add Persistence Context
            // builder.Services.Configure<PersistenceContext>(configuration.GetSection("PersistenceContext"));
            builder.Services.Configure<UpConnectionUrl>(configuration.GetSection("UpConnectionUrl"));
            // every lib has its own services exteension section
            builder.Services.AddRestLibServices(configuration);
        }


        public static bool ConfigureCors(WebApplicationBuilder builder, string corsName)
        {

            string[]? ao = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

            if (ao == null) return false;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsName,
                    policy =>
                    {
                        policy.WithOrigins(ao!)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });

            });
            return true;

        }
    }
}
