using FreelancerDirectoryAPI.Domain.Entities;
using FreelancerDirectoryAPI.Domain.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    //if (context.Database.IsSqlServer())
                    //{
                    //    await context.Database.MigrateAsync();
                    //}
                    await context.Database.MigrateAsync();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


                  
                    await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
                   

                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(((context, configuration) =>
                {
                    configuration.Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .WriteTo.Sentry(o =>
                        {
                            // Debug and higher are stored as breadcrumbs (default is Information)
                            o.MinimumBreadcrumbLevel = LogEventLevel.Debug;
                            // Warning and higher is sent as event (default is Error)
                            o.MinimumEventLevel = LogEventLevel.Information;
                            o.Environment = context.HostingEnvironment.EnvironmentName;
                            o.Dsn = "";

                        })
                        //.WriteTo.Elasticsearch(
                        //    new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                        //    {
                        //        IndexFormat =
                        //            $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        //        AutoRegisterTemplate = true,
                        //        NumberOfShards = 2,
                        //        NumberOfReplicas = 1
                        //    })

                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);
                }))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            ;
    }
}
