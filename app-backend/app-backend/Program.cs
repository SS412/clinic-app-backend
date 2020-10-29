using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using app_persistence;
using System.Threading.Tasks;
    
namespace app_backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            using var scope = webHost.Services.CreateScope();
            //Open context for first time 
            var dbContext = scope.ServiceProvider.GetRequiredService<Func<Db>>()();
            //Ensure all migrations are run on target database before starting API 
            await dbContext.Database.MigrateAsync();

            await webHost.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
