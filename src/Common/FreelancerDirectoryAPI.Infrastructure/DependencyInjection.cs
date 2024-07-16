using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Infrastructure.Files;
using FreelancerDirectoryAPI.Infrastructure.Identity;
using FreelancerDirectoryAPI.Infrastructure.Services;
using FreelancerDirectoryAPI.Infrastructure.Services.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerDirectoryAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)//, IWebHostEnvironment environment)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IHttpClientHandler, HttpClientHandler>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<ITokenService, TokenService>();
            return services;
        }
    }
}
