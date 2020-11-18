using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_backend.Extensions
{
    /// <summary>
    /// Extension methods used in Startup class
    /// </summary>
    internal static class StartupConfigurationExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.SetIsOriginAllowed(origin =>
                    // TODO: add strict CORS config
                    true ||
                    origin.Contains("http://localhost:")
                );

                builder.AllowAnyMethod();

                builder.AllowAnyHeader();

                // CREDENTIALS MUST BE ENABLED FOR USING SIGNALR, EVEN WHEN AUTHENTICATION IS NOT USED
                builder.AllowCredentials();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void AddBusinessDependencies(
            this IServiceCollection services,
            string connectionString
            )
        {
            // DbContext creation

        }
    }
}
